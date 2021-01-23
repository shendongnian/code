    ToolTip toolTip1 = new ToolTip();
    void initMethod()
    {
     lstList.MouseMove += new MouseEventHandler(lstList_MouseMove);//mousemove handler
     this.lstList.ShowItemToolTips = true;            
     toolTip1.SetToolTip(lstList,"");// init the tooltip
     ...
     ListViewItem value = lstList.Items.Add(name, name, 0);
     ...
     if (lstList.Columns.Contains(lstColErrorCode))
     {                                
     ListViewItem.ListViewSubItem lvs =  value.SubItems.Add(new ListViewItem.ListViewSubItem(value, errorCode.ToString()));
       lvs.Tag = "mydecimal"; // only the decimal subitem will be tooltiped
    }
    }
