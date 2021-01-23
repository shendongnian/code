    using System;
    using System.Data;
    using System.Configuration;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.Collections;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    namespace Q11456633WebApp
    {
        /// <summary>
        /// Extension of <see cref="DropDownList"/> supporting reference to the 
        /// object related to the selected line.
        /// </summary>
        [ValidationProperty("SelectedItem")]
        [SupportsEventValidation]
        [ToolboxData(
          "<{0}:DropDownListKeepRef runat=\"server\"></{0}:DropDownListKeepRef>")]
        public class DropDownListKeepRef : DropDownList
        {
            protected override void PerformDataBinding(System.Collections.IEnumerable dataSource)
            {
                if (!String.IsNullOrEmpty(this.DataValueField))
                {
                    throw new InvalidOperationException(
                        "'DataValueField' cant be define in this implementation. This Control use the index of list");
                }
    
                this.Items.Clear();
                ArrayList list = new ArrayList();
                int valueInt = 0;
                if (this.FirstNull)
                {
                    list.Add(null);
                    this.Items.Add(new ListItem(this.FirstNullText, valueInt.ToString()));
                    valueInt++;
                }
                foreach (object item in dataSource)
                {
                    String textStr = null;
                    if (item != null)
                    {
                        Object textObj = item.GetType().GetProperty(this.DataTextField).GetValue(item, null);
                        textStr = textObj != null ? textObj.ToString() : "";
                    }
                    else
                    {
                        textStr = "";
                    }
    
                    //montando a listagem
                    list.Add(item);
                    this.Items.Add(new ListItem(textStr, valueInt.ToString()));
                    valueInt++;
                }
                this.listOnSession = list;
            }
    
            private bool firstNull = false;
            /// <summary>
            /// If <c>true</ c> include a first line that will make reference to <c>null</c>,
            /// otherwise there will be only the line from the DataSource.
            /// </summary>
            [DefaultValue(false)]
            [Themeable(false)]
            public bool FirstNull
            {
                get
                {
                    return firstNull;
                }
                set
                {
                    firstNull = value;
                }
            }
    
            private string firstNullText = "";
            /// <summary>
            /// Text used if you want a first-line reference to <c>null</c>.
            /// </summary>
            [DefaultValue("")]
            [Themeable(false)]
            public virtual string FirstNullText
            {
                get
                {
                    return firstNullText;
                }
                set
                {
                    firstNullText = value;
                }
            }
    
            /// <summary>
            /// List that keeps the object instances.
            /// </summary>
            private IList listOnSession
            {
                get
                {
                    return this.listOfListsOnSession[this.UniqueID + "_listOnSession"];
                }
                set
                {
                    this.listOfListsOnSession[this.UniqueID + "_listOnSession"] = value;
                }
            }
    
            #region to avoid memory overload
            private string currentPage
            {
                get
                {
                    return (string)HttpContext.Current.Session["DdlkrCurrentPage"];
                }
                set
                {
                    HttpContext.Current.Session["DdlkrCurrentPage"] = value;
                }
            }
    
            /// <summary>
            /// Every time you change page, lists for the previous page will be 
            /// discarded from memory.
            /// </summary>
            private IDictionary<String, IList> listOfListsOnSession
            {
                get
                {
                    if (currentPage != this.Page.Request.ApplicationPath)
                    {
                        currentPage = this.Page.Request.ApplicationPath;
                        HttpContext.Current.Session["DdlkrListOfListsOnSession"] = new Dictionary<String, IList>();
                    }
                    if (HttpContext.Current.Session["DdlkrListOfListsOnSession"] == null)
                    {
                        HttpContext.Current.Session["DdlkrListOfListsOnSession"] = new Dictionary<String, IList>();
                    }
    
                    return (IDictionary<String, IList>)HttpContext.Current.Session["DdlkrListOfListsOnSession"];
                }
            } 
            #endregion
    
            public Object SelectedObject
            {
                get
                {
                    if (this.SelectedIndex > 0 && this.listOnSession.Count > this.SelectedIndex)
                        return this.listOnSession[this.SelectedIndex];
                    else
                        return null;
                }
                set
                {
                    if (!this.listOnSession.Contains(value))
                    {
                        throw new IndexOutOfRangeException(
                            "Objeto nao contido neste 'DropDownListKeepRef': " +
                            value != null ? value.ToString() : "<null>");
                    }
                    else
                    {
                        this.SelectedIndex = this.listOnSession.IndexOf(value);
                    }
                }
            }
    
            /// <summary>
            /// List of related objects.
            /// </summary>
            public IList Objects
            {
                get
                {
                    return new ArrayList(this.listOnSession);
                }
            }
    
            [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
            protected override void LoadViewState(object savedState)
            {
                object[] totalState = null;
                if (savedState != null)
                {
                    totalState = (object[])savedState;
                    if (totalState.Length != 3)
                    {
                        throw new InvalidOperationException("View State Invalida!");
                    }
                    // Load base state.
                    int i = 0;
                    base.LoadViewState(totalState[i++]);
                    // Load extra information specific to this control.
                    this.firstNull = (bool)totalState[i++];
                    this.firstNullText = (String)totalState[i++];
                }
            }
    
            [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
            protected override object SaveViewState()
            {
                object baseState = base.SaveViewState();
                object[] totalState = new object[3];
                int i = 0;
                totalState[i++] = baseState;
                totalState[i++] = this.firstNull;
                totalState[i++] = this.firstNullText;
                return totalState;
            }
        }
    }
