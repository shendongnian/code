        public static bool ValidateAntiXSS(string inputParameter)
        {
            if (!string.IsNullOrEmpty(inputParameter))
            {
                // Following regex convers all the js events and html tags mentioned in followng links.
                //https://www.owasp.org/index.php/XSS_Filter_Evasion_Cheat_Sheet                 
                //https://msdn.microsoft.com/en-us/library/ff649310.aspx
               
                var pattren = new StringBuilder();
                //Checks any js events i.e. onKeyUp(), onBlur() etc.                              
                pattren.Append("((FSCommand|onAbort|onActivate|onAfterPrint|onAfterUpdate|onBeforeActivate|onBeforeCopy|onBeforeCut|onBeforeDeactivate|onBeforeEditFocus|");
                pattren.Append("onBeforePaste|onBeforePrint|onBeforeUnload|onBeforeUpdate|onBegin|onBlur|onBounce|onCellChange|onChange|onClick|");
                pattren.Append("onContextMenu|onControlSelect|onCopy|onCut|onDataAvailable|onDataSetChanged|onDataSetComplete|onDblClick|onDeactivate|onDrag|");
                pattren.Append("onDragEnd|onDragLeave|onDragEnter|onDragOver|onDragDrop|onDragStart|onDrop|onEnd|onError|onErrorUpdate|");
                pattren.Append("onFilterChange|onFinish|onFocus|onFocusIn|onFocusOut|onHashChange|onHelp|onInput|onKeyDown|onKeyPress|");
                pattren.Append("onKeyUp|onLayoutComplete|onLoad|onLoseCapture|onMediaComplete|onMediaError|onMessage|onMouseDown|onMouseEnter|onMouseLeave|");
                pattren.Append("onMouseMove|onMouseOut|onMouseOver|onMouseUp|onMouseWheel|onMove|onMoveEnd|onMoveStart|onOffline|onOnline|");
                pattren.Append("onOutOfSync|onPaste|onPause|onPopState|onProgress|onPropertyChange|onReadyStateChange|onRedo|onRepeat|onReset|");
                pattren.Append("onResize|onResizeStart|onResume|onReverse|onRowsEnter|onRowExit|onRowDelete|onRowInserted|onScroll|");
                pattren.Append("onSeek|onSelect|onSelectionChange|onSelectStart|onStart|onStop|onStorage|onSyncRestored|onSubmit|onTimeError|");
                pattren.Append(@"onTrackChange|onUndo|onUnload|onURLFlip|seekSegmentTime)\s*\((\s*\w*\s*[,\w\s*]?)*\))");
                //Checks any html tags i.e. <script, <embed, <object etc.
                pattren.Append("|(<(applet|body|embed|frame|script|frameset|html|iframe|img|style|layer|link|ilayer|meta|object|bgsound))");
                //Checks alert & any custom js functions i.e. function myexe(a,b,....){
                pattren.Append(@"|((alert\s*\(\s*.*\s*\)|function\s+\w*\s*\((\s*\w*\s*[,\w\s*]?)*\)))");
                return !Regex.IsMatch(System.Web.HttpUtility.UrlDecode(inputParameter), pattren.ToString(), RegexOptions.IgnoreCase);               
                
            }
            return true;
        }
