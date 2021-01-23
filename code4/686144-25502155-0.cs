    <phone:WebBrowser
                    x:Name="WebBrowser"
                    IsHitTestVisible="True"
                    IsScriptEnabled="True"
                    LoadCompleted="WebBrowser_LoadCompleted"
                                                                    ScriptNotify="WebBrowser_ScriptNotify">
                              
    </phone:WebBrowser>
     
    private void WebBrowser_LoadCompleted(object sender, NavigationEventArgs e)
    {
                    if (WebBrowser.IsScriptEnabled)
                    {
                                    var JavaScriptText =
                                                    @"function ReplaceBadXmlChars(str) {
                                                    var stri = str.split('&').join('&amp;');
                                                    stri = stri.split('<').join('&lt;');
                                                    stri = stri.split('>').join('&gt;');
                                                    stri = stri.split("'").join('&apos;');
                                                    stri = stri.split('"').join('&quot;');
                                                    return stri;
                                    }
     
                                    function FindParentByTag(item, tag) {
                                                    if (!item.parentNode) return null;
                                                    if (item.tagName.toLowerCase() == tag.toLowerCase()) {
                                                                    return item;
                                                    } else {
                                                                    return FindParentByTag(item.parentNode, tag);
                                                    }
                                    }
     
                                    function OnClick() {
                                                    var linkItem = FindParentByTag(event.srcElement, 'a');
                                                    var imageItem = FindParentByTag(event.srcElement, 'img');
     
                                                    var zoom = screen.deviceXDPI / screen.logicalXDPI;
                                                    var valid = false;
                                                    var notifyMsg = '<Click ';
                                                    {
                                                                    notifyMsg += 'pos="' + parseInt(event.clientX * zoom) + ',' + parseInt(event.clientY * zoom) + '" ';
                                                                    if (linkItem != null && linkItem.href != null && !linkItem.href.startsWith("javascript")) {
                                                                                    notifyMsg += 'url="' + ReplaceBadXmlChars(linkItem.href) + '" ';
                                                                                    valid = true;
                                                                    }
     
                                                                    if (imageItem != null && imageItem.href != null && !linkItem.href.startsWith("javascript")) {
                                                                                    notifyMsg += 'img="' + ReplaceBadXmlChars(imageItem.src) + '" ';
                                                                                    valid = true;
                                                                    }
                                                    }
                                                    notifyMsg += '/>';
                                                    if (valid) {
                                                                    window.external.notify(notifyMsg);
                                                                    return false;
                                                    }
                                    }
     
     
                                    function RegisterClickNotification() {
                                                    window.document.onclick = OnClick;
     
                                                    window.document.body.addEventListener('MSPointerDown', function(evt) {
                                                                    evt = evt || window.event;
     
                                                                    var linkItem = FindParentByTag(evt.srcElement, 'a');
                                                                    var imageItem = FindParentByTag(evt.srcElement, 'img');
     
                                                                    window.devicePixelRatio = window.screen.deviceXDPI / window.screen.logicalXDPI;
                                                                    var doc = window.document.documentElement;
                                                                    var left = (window.pageXOffset || doc.scrollLeft) - (doc.clientLeft || 0);
                                                                    var top = (window.pageYOffset || doc.scrollTop) - (doc.clientTop || 0);
     
                                                                    var timerId = window.setTimeout(function() {
                                                                                    var notifyMsg = 'pos="' + parseInt((evt.clientX - left)) + ',' + parseInt((evt.clientY - top)) + '" ';
     
                                                                                    if (linkItem != null && linkItem.href != null) {
                                                                                                    notifyMsg += 'url="' + ReplaceBadXmlChars(linkItem.href) + '" ';
                                                                                    }
     
                                                                                    if (imageItem != null && imageItem.href != null) {
                                                                                                    notifyMsg += 'img="' + ReplaceBadXmlChars(imageItem.src) + '" ';
                                                                                    }
     
                                                                                    window.external.notify('<Hold ' + notifyMsg + '/>');
                                                                    }, 500);
                                                                    StopLoading();
                                                                    evt.target.data = timerId;
                                                    });
                                    }
     
                                    window.document.body.addEventListener('MSPointerUp', function (evt) {
                                                    window.clearTimeout(evt.target.data);
                                    });
     
                                    window.document.body.addEventListener('MSPointerMove', function (evt) {   
                                                    window.clearTimeout(evt.target.data);   
                                    });
     
                                    window.document.body.addEventListener('MSPointerOut', function (evt) {
                                                    window.clearTimeout(evt.target.data);
                                    });
     
                                    window.document.body.addEventListener('pointerup', function (evt) {
                                     
                                    });"
     
                                    WebBrowser.InvokeScript("eval", new string[] { JavaScriptText });
                                    WebBrowser.InvokeScript("RegisterClickNotification");
                                    WebBrowser.InvokeScript("execScript", new string[] {
                                    "function eventListener(evt) {if (evt.type == 'MSPointerDown'){ gestureHandler.addPointer(evt.pointerId); return; } if (evt.detail & evt.MSGESTURE_FLAG_END) {  window.external.notify(evt.srcElement.tagName);}}" });
                                    WebBrowser.InvokeScript("execScript", new string[] { "document.addEventListener('MSGestureHold', eventListener, false); document.addEventListener('MSPointerDown', eventListener, false);  gestureHandler = new MSGesture(); gestureHandler.target = document.body;" });
                    }
    }
