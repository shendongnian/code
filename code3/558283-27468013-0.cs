    using System;
    using System.Threading;
    using FluentSharp.Web35;
    using FluentSharp.WinForms;
    using FluentSharp.CoreLib;
    using FluentSharp.CoreLib.API;
    
    namespace FluentSharp.Watin
    {
        public static class WatiN_IE_ExtensionMethods_Javascript
        {
        	
            public static object invokeScript(this WatiN_IE ie, string functionName)
            {
                return ie.invokeScript(functionName, null);
            }
        	
            public static object invokeScript(this WatiN_IE ie, string functionName, params object[] parameters)
            {
                //"[WatiN_IE] invokeScript '{0}' with parameters:{1}".info(functionName ,parameters.size());
                return ie.invokeScript(true, functionName, parameters);
            }	
        		
            public static object invokeScript(this WatiN_IE ie, bool waitForExecutionComplete, string functionName, params object[] parameters)
            {
                var sync = new AutoResetEvent(false);
                object responseValue = null;
                ie.WebBrowser.invokeOnThread(
                    ()=>{
                            var document = ie.WebBrowser.Document;
                            if (parameters.isNull())
                                responseValue = document.InvokeScript(functionName); 
                            else
                                responseValue = document.InvokeScript(functionName, parameters); 
                            sync.Set();	
                    });
                if (waitForExecutionComplete)
                    sync.WaitOne();
                return responseValue;	
            }
        	
            public static object invokeEval(this WatiN_IE ie, string evalScript)
            {
                var evalParam = "(function() { " + evalScript + "})();";
                //"[WatiN_IE] invokeEval evalParam: {0}".debug(evalParam);
                return ie.invokeScript("eval", evalParam);   
            }
            public static WatiN_IE.ToCSharp injectJavascriptFunctions(this WatiN_IE ie)
            {
                return ie.injectJavascriptFunctions(false);
            }
        	
            public static WatiN_IE.ToCSharp injectJavascriptFunctions(this WatiN_IE ie, bool resetHooks)
            {
                if (ie.WebBrowser.isNull())
                    "in InjectJavascriptFunctions, ie.WebBrowser was null".error();
                else
                {
                    if (ie.WebBrowser.ObjectForScripting.isNull() || resetHooks)  
                    {
                        ie.WebBrowser.ObjectForScripting = new WatiN_IE.ToCSharp();
        				
                        "Injecting Javascript Hooks * Functions for page: {0}".debug(ie.url());
                        ie.eval("var o2Log = function(message) { window.external.write(message) };");
                        ie.invokeScript("o2Log","Test from Javascript (via toCSharp(message) )");
                        ie.eval("$o2 = window.external");
                        "Injection complete (use o2Log(...) or $o2.write(...)  to talk back to O2".info();
                        return (ie.WebBrowser.ObjectForScripting as WatiN_IE.ToCSharp);
                    }
                    else 
                    {
                        if((ie.WebBrowser.ObjectForScripting is WatiN_IE.ToCSharp))
                            return (ie.WebBrowser.ObjectForScripting as WatiN_IE.ToCSharp);
                        else
                            "in WatiN_IE injectJavascriptFunctions, unexpected type in ie.WebBrowser.ObjectForScripting: {0}".error(ie.WebBrowser.ObjectForScripting.typeName());					
                    }
    						
                }
                return null;
            }
        	
            public static object downloadAndExecJavascriptFile(this WatiN_IE ie, string url)
            {
                "[WatiN_IE] downloadAndExecJavascriptFile: {0}".info(url);
                var javascriptCode = url.uri().getHtml();
                if (javascriptCode.valid())
                    ie.eval(javascriptCode);
                return ie;
            }
        	    	
            public static WatiN_IE injectJavascriptFunctions_onNavigate(this WatiN_IE ie)
            {
        		
                ie.onNavigate((url)=> ie.injectJavascriptFunctions());
                return ie;
            }
    
            public static WatiN_IE setOnAjaxLog(this WatiN_IE ie, Action<string, string,string,string> onAjaxLog)
            {
                (ie.WebBrowser.ObjectForScripting as WatiN_IE.ToCSharp).OnAjaxLog = onAjaxLog;
                return ie;
            }
        
            public static WatiN_IE eval_ASync(this WatiN_IE ie, string script)
            {
                O2Thread.mtaThread(()=> ie.eval(script));
                return ie;
            }
        	
            public static WatiN_IE eval(this WatiN_IE ie, string script)
            {
                return ie.eval(script, true);
            }
        	
            public static WatiN_IE eval(this WatiN_IE ie, string script, bool waitForExecutionComplete)
            {
                var executionThread = O2Thread.staThread(()=> ie.IE.RunScript(script));			
                if (waitForExecutionComplete)
                    executionThread.Join();
                return ie;	
            }
        	
            public static WatiN_IE alert(this WatiN_IE ie, string alertScript)
            {
                return ie.eval("alert({0});".format(alertScript));
            }
        	
            public static object getJsObject(this WatiN_IE ie)
            {
                var toCSharpProxy = ie.injectJavascriptFunctions();
                if (toCSharpProxy.notNull())
                    return toCSharpProxy.getJsObject();
                return null;    	
            }
        	
            public static T getJsObject<T>(this WatiN_IE ie, string jsCommand)
            {
                var jsObject = ie.getJsObject(jsCommand);
                if (jsObject is T)
                    return (T)jsObject;
                return default(T);
            }
        	
            public static bool doesJsObjectExists(this WatiN_IE ie, string jsCommand)
            {
                var toCSharpProxy = ie.injectJavascriptFunctions();
                if (toCSharpProxy.notNull())
                {
                    var command = "window.external.setJsObject(typeof({0}))".format(jsCommand);
                    ie.invokeEval(command);
                    ie.remapInternalJsObject();    			
                    return toCSharpProxy.getJsObject().str()!="undefined";
                }
                return false;
            }
        	
            public static object getJsVariable(this WatiN_IE ie, string jsCommand)
            {
                return ie.getJsObject(jsCommand);
            }
        	
            public static object getJsObject(this WatiN_IE ie, string jsCommand)
            {
                var toCSharpProxy = ie.injectJavascriptFunctions();
                if (toCSharpProxy.notNull())
                {
                    var command = "window.external.setJsObject({0})".format(jsCommand);
                    ie.invokeEval(command);
                    ie.remapInternalJsObject();    			
                    return toCSharpProxy.getJsObject();
                }
                return null;
            }    	    	
        	
            public static WatiN_IE remapInternalJsObject(this WatiN_IE ie)
            {		
                //"setting JS _jsObject variable to getJsObject()".info();
                ie.invokeEval("_jsObject = window.external.getJsObject()"); // creates JS variable to be used from JS
                return ie;
            }
        	
            public static WatiN_IE setJsObject(this WatiN_IE ie, object jsObject)
            {
                var toCSharpProxy = ie.injectJavascriptFunctions();
                if (toCSharpProxy.notNull())    		
                {
                    toCSharpProxy.setJsObject(jsObject);
                    ie.remapInternalJsObject();
                }
                return ie;
            }
        	
            public static object waitForJsObject(this WatiN_IE watinIe)
            {
                return watinIe.waitForJsObject(500, 20);
            }
    		
            public static object waitForJsObject(this WatiN_IE watinIe, int sleepMiliseconds, int maxSleepTimes)
            {					
                "[WatiN_IE][waitForJsObject] trying to find jsObject for {0} x {1} ms".info(maxSleepTimes, sleepMiliseconds);
                watinIe.setJsObject(null);
                for(var i = 0; i < maxSleepTimes ; i++)
                {
                    var jsObject = watinIe.getJsObject();
                    if(jsObject.notNull())
                    {
                        "[watinIe][waitForJsObject] got value: {0} (n tries)".info(jsObject, i);
                        return jsObject;
                    }
    					
                    watinIe.sleep(500, false);
                }
                "[WatiN_IE][waitForJsObject] didn't find jsObject after {0} sleeps of {1} ms".error(maxSleepTimes, sleepMiliseconds);
                return null;
            }
    		
            public static object waitForJsVariable(this WatiN_IE watinIe, string jsCommand)
            {
                return watinIe.waitForJsVariable(jsCommand,  500, WatiN_IE_ExtensionMethods.WAITFORJSVARIABLE_MAXSLEEPTIMES);
            }
    		
            public static object waitForJsVariable(this WatiN_IE watinIe, string jsCommand, int sleepMiliseconds, int maxSleepTimes)
            {	
                "[WatiN_IE][waitForJsVariable] trying to find jsObject called '{0}' for {1} x {2} ms".info(jsCommand, maxSleepTimes, sleepMiliseconds);			
                watinIe.setJsObject(null);
                for(var i = 0; i < maxSleepTimes ; i++)
                {
                    if (watinIe.doesJsObjectExists(jsCommand))
                    {
                        var jsObject = watinIe.getJsObject(jsCommand);
                        "[watinIe][waitForJsVariable] got value: {0} ({1} tries)".info(jsObject, i);
                        return jsObject;
                    }					
                    watinIe.sleep(500, false);
                }
                "[WatiN_IE][waitForJsVariable] didn't find jsObject called '{0}' after {1} sleeps of {2} ms".error(jsCommand, maxSleepTimes, sleepMiliseconds);
                return null;
            }
    		
            public static WatiN_IE deleteJsVariable(this WatiN_IE watinIe, string jsVariable)
            {
                var evalString = "try { delete " + jsVariable + " } catch(exception) { }";
                watinIe.eval(evalString);
                return watinIe;
            }
    		
        	    	
        }
    }
