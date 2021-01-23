    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    using System.ComponentModel;
    using System.Data;
    using System.IO;
    using System.Collections;
    using System.Web;
    using Microsoft.Win32;
    namespace WCFJobsLibrary
    {
    
            // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Jobs" in both code and config file together.
           public class Jobs : IJobs
        {
        
        
           #region IJobs Members            
            
            
        
            //Files Manager
            public ReturnClass FilesToControl(List<Item> lstNewItems)
           {
               try
               {
                   String ThisisAnItemToControl = "";
                   String ThisIsItsType = "";
        
                   for (int i = 0; i < lstNewItems.Count; i++) // Loop through List with for
                   {
                       ThisisAnItemToControl = lstNewItems[i].Paramater;
                       ThisIsItsType = lstNewItems[i].Type;
        
                   }
        
                   return new ReturnClass(1, ThisisAnItemToControl, String.Empty, null, null, null);
        
               }
        
               catch (Exception ex)
               {
        
                   return new ReturnClass(-1, ex.Message.ToString(), ex.InnerException.ToString(), null, null, null);
        
               }           
        
        
           }
            
            }
           #endregion
    
    
