    using System;
    using Microsoft.Office.Interop.Excel;
    public partial class CustPropExample
    {
      /// <summary>
      /// delete and then store the custom property by passed key and value
      /// </summary>
      bool bExcelCustProp_Replace(Worksheet wkSheet,
        string custPropKey,
        string custPropVal)
      {
        if (!ExcelCustProp_DeleteByKey(wkSheet, custPropKey))
          return (false);
    
        if (!ExcelCustProp_Add(wkSheet, custPropKey, custPropVal))
          return (false);
    
        return (true);
      }
    
      /// <summary>
      /// return the custom property value of passed key
      /// </summary>
      string ExcelCustProp_Get(Worksheet wkSheet,
        string key)
      {
        try
        {
          for (int i = 1; i <= wkSheet.CustomProperties.Count; i++) // NOTE: 1-based !!!!!!!!
          {
            if (wkSheet.CustomProperties.get_Item(i).Name == key)
              return (wkSheet.CustomProperties.get_Item(i).Value);
          }
        }
        catch (Exception ex)
        {
          ShowErrorMsg("Error with getting cust prop; key [" + key + "], exc: " + ex.Message, false);
        }
    
        return (string.Empty);
      }
    
      /// <summary>
      /// add cust prop
      /// </summary>
      bool ExcelCustProp_Add(Worksheet wkSheet,
        string key,
        string custPropVal)
      {
        try
        {
          wkSheet.CustomProperties.Add(key, custPropVal);
        }
        catch (Exception ex)
        {
          return(ShowErrorMsg("Error in adding cust prop: " + ex.Message, false));
        }
        return (true);
      }
    
      /// <summary>
      /// if passed key exists, delete it
      /// </summary>
      bool ExcelCustProp_DeleteByKey(Worksheet wkSheet,
        string key)
      {
        try
        {
          for (int i = 1; i <= wkSheet.CustomProperties.Count; i++) // NOTE: 1-based !!!!!!!!
          {
            if (wkSheet.CustomProperties.Item[i].Name == key)
            {
              wkSheet.CustomProperties.Item[i].Delete();
              break;
            }
          }
        }
        catch (Exception ex)
        {
          return(ShowErrorMsg("Error deleting cust prop (key='" + key + "') - " + ex.Message, false));
        }
    
        return (true);
      }
    
      /// <summary>
      /// stub for error handling
      /// </summary>
      bool ShowErrorMsg(string msg,
        bool retval)
      {
        System.Windows.Forms.MessageBox.Show(msg);
        return (retval);
      }
    
    }
    
    
