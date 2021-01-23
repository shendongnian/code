    using System; 
    using System.ComponentModel; 
    using System.Configuration; 
    using System.Web.UI; 
    using System.Web.UI.WebControls; 
    
    namespace CustomGridView 
    { 
     /// <summary> 
     /// Summary description for ClickableGridView 
     /// </summary> 
     public class ClickableGridView : GridView 
     { 
       public string RowCssClass 
       { 
         get 
         { 
           string rowClass = (string)ViewState["rowClass"]; 
           if (!string.IsNullOrEmpty(rowClass)) 
             return rowClass; 
           else 
             return string.Empty; 
         } 
         set 
         { 
           ViewState["rowClass"] = value; 
         } 
       } 
    
       public string HoverRowCssClass 
       { 
         get 
         { 
           string hoverRowClass = (string)ViewState["hoverRowClass"]; 
           if (!string.IsNullOrEmpty(hoverRowClass)) 
             return hoverRowClass; 
           else 
             return string.Empty; 
         } 
         set 
         { 
           ViewState["hoverRowClass"] = value; 
         } 
       } 
    
       private static readonly object RowClickedEventKey = new object(); 
    
       public event GridViewRowClicked RowClicked; 
       protected virtual void OnRowClicked(GridViewRowClickedEventArgs e) 
       { 
         if (RowClicked != null) 
           RowClicked(this, e); 
       } 
    
       protected override void RaisePostBackEvent(string eventArgument) 
       { 
         if (eventArgument.StartsWith("rc")) 
         { 
           int index = Int32.Parse(eventArgument.Substring(2)); 
           GridViewRowClickedEventArgs args = new GridViewRowClickedEventArgs(Rows[index]); 
           OnRowClicked(args); 
         } 
         else 
           base.RaisePostBackEvent(eventArgument); 
       } 
    
       protected override void PrepareControlHierarchy() 
       { 
         base.PrepareControlHierarchy(); 
    
         for (int i = 0; i < Rows.Count; i++) 
         { 
           string argsData = "rc" + Rows[i].RowIndex.ToString(); 
           Rows[i].Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(this, argsData)); 
    
           if (RowCssClass != string.Empty) 
             Rows[i].Attributes.Add("onmouseout", "this.className='" + RowCssClass + "';"); 
    
           if (HoverRowCssClass != string.Empty) 
             Rows[i].Attributes.Add("onmouseover", "this.className='" + HoverRowCssClass + "';"); 
         } 
       } 
     } 
    
     public class GridViewRowClickedEventArgs : EventArgs 
     { 
       private GridViewRow _row; 
    
       public GridViewRowClickedEventArgs(GridViewRow aRow) 
         : base() 
       { 
         _row = aRow; 
       } 
    
       public GridViewRow Row 
       { 
         get 
         { return _row; } 
       } 
     } 
    
     public delegate void GridViewRowClicked(object sender, GridViewRowClickedEventArgs args); 
    } 
