    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using VMPortal.Tools;
    public class GridViewExColumn : DataControlField
    {
        public string HeaderToolTip { get; set; }
        public string GridViewID { get; set; }
        public string SearchType { get; set; }
        public string DataField
        {
            get
            {
                object value = ViewState["DataField"];
                if (value != null)
                    return value.ToString();
                return string.Empty;
            }
            set
            {
                ViewState["DataField"] = value;
                OnFieldChanged();
            }
        }
        protected override DataControlField CreateField()
        {
            return new BoundField();
        }
        public override void InitializeCell(DataControlFieldCell cell, DataControlCellType cellType, DataControlRowState rowState, int rowIndex)
        {
            base.InitializeCell(cell, cellType, rowState, rowIndex);
            
            if (cellType == DataControlCellType.Header)
            {
                var lb = new LinkButton
                {
                    Text = HeaderText,
                    ToolTip = String.IsNullOrWhiteSpace(HeaderToolTip) ? HeaderText : HeaderToolTip,
                    CommandName = "Sort",
                    CommandArgument = DataField
                };
                
                var tt = cell.Controls;
                cell.Controls.Add(lb);
                if (!String.IsNullOrWhiteSpace(SearchType))
                {
                    // Add filter control
                    var ctrlFilter = Control.Page.LoadControl("~/Controls/GridViewFilter.ascx") as GridViewFilter;
                    cell.Controls.Add(ctrlFilter);
                    ctrlFilter.ID = GridViewID + DataField;
                    ctrlFilter.ColumnName = DataField;
                    ctrlFilter.AssociatedControlType = SearchType;
                    ctrlFilter.FilterApplied += ctrlFilter_FilterApplied;
                }
            }
            else if (cellType == DataControlCellType.DataCell)
                cell.DataBinding += new EventHandler(cell_DataBinding);
        }
        protected void cell_DataBinding(object sender, EventArgs e)
        {
            var cell = (TableCell)sender;
            var dataItem = DataBinder.GetDataItem(cell.NamingContainer);
            var dataValue = DataBinder.GetPropertyValue(dataItem, DataField);
            string value = dataValue != null ? dataValue.ToString() : "";
            cell.Text = value;
        }
        protected void ctrlFilter_FilterApplied(object sender, EventArgs e)
        {
            var filterExpression = sender as FilterExpression;
            if (filterExpression != null)
            {
                if (FilterApplied != null)
                    FilterApplied(null, EventArgs.Empty);
            }
        }
