    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.Windows.Automation;
    using   Utils;
    namespace ControllerX.Executions
    {
       
        
        /// <summary>
        /// this class provide searching mechanisms
        /// </summary>
        class searching
        {
               
            public static void search(string Sentence)
            {
    
                if ( Sentence == String.Empty) return; //no need to search empty value
                try
                {
                    searchInFireFox( Sentence);
                }
                catch (Exception ex)
                {
                    Util.Debuglog(ex.Message);
    
                }//ex
            }
    
    
            private static AutomationElement cached;
            private static Process oldproc;
    
            /// <summary>
            /// search inside firefox
            /// </summary>
            /// <param name="search_term"></param>
            private static  void searchInFireFox(string search_term)
            { 
                //search using firefox
                if (oldproc != null && oldproc.HasExited == false && cached!=null  )
                { 
                    object cachedPattern;
                    if (true == cached.TryGetCachedPattern(InvokePattern.Pattern, out cachedPattern))
                    {
                        InvokePattern iPattern = cachedPattern as InvokePattern  ;
                        Util.BringToFront(oldproc.MainWindowHandle);
                        if (iPattern != null) { iPattern.Invoke(); Util.SimulateMessage(search_term, true); }
                        Util.Debuglog("Invoked within cached :" + search_term);
                    }
    
                    return; 
                }//
                Process firefox = null;
                if (oldproc != null && oldproc.HasExited == true) { oldproc.Close();} 
                else { firefox=oldproc;Util.Debuglog("firefox=oldproc");  };
                cached = null;
                if (firefox==null) firefox = Util.FindByName("firefox"); 
                if (firefox != null)
                {
                    cached = InvokeAndCache(search_term,firefox.MainWindowHandle);
                   oldproc=firefox;
                }//if
                else if(   open_new(search_term)==false  )
                    Utils.ErrorHandle.notify_user("Could not search with firefox"); 
    
            }//
    
      
            private static bool open_new(string search_term)
            {
                bool ok = false;
                Process pfirefox = null;
                pfirefox =Util.StartProc(@"firefox.exe" ,
                                     "-new-tab -search \"" + search_term + "\"",
                                     null,
                                     false);
                oldproc = pfirefox;
                if (pfirefox != null) { ok = true; Util.Debuglog("opened in new : " + search_term); }
                return ok;
            }//open new
    
            private static AutomationElement InvokeAndCache(string search_term,IntPtr handle)
            {
                AutomationElement  search  = null;
                try
                {
                    AutomationElement aeDesktop = AutomationElement.RootElement;
                    AutomationElement aeBrowser = AutomationElement.FromHandle(handle);
                    // Set up the request.
                    CacheRequest cacheRequest = new CacheRequest();
                    cacheRequest.AutomationElementMode = AutomationElementMode.None;
                    cacheRequest.TreeFilter = Automation.ControlViewCondition;
                    cacheRequest.Add(AutomationElement.ControlTypeProperty);
                    cacheRequest.Add(InvokePattern.Pattern);
                    System.Windows.Automation.Condition conLocation = new OrCondition(
                        new PropertyCondition(AutomationElement.NameProperty, "Navigation Toolbar"),
                        new PropertyCondition(AutomationElement.NameProperty, "Панель навигации") );//russian name of the tab
                    AutomationElement navigation = null;
                    navigation = aeBrowser.FindFirst(TreeScope.Descendants, conLocation);
                    cacheRequest.Push();
                    if (navigation != null)
                    {
                        AutomationElementCollection elList = navigation.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
                        if (elList != null && elList.Count > 1) 
                            search = elList[elList.Count - 1];
                    }
                        if (search != null)
                    {
                        Util.BringToFront(handle);
                        InvokePattern iPattern = search.GetCachedPattern(InvokePattern.Pattern) as InvokePattern;
                        cached = search;
                        if (iPattern != null) { 
                            iPattern.Invoke(); Util.SimulateMessage(search_term,true);
                            Util.Debuglog("cached then invoked : " + search_term);
                        }//if iPattern
                    }//if
                    cacheRequest.Pop();
                }
                catch (Exception ex)
                {
                    Util.Debuglog(ex.Message);
                }//try catch
                return search;
            }
    
    
        }//end class
    }
