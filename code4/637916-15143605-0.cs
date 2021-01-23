           // ...
           else if (RowType == DataControlRowType.DataRow || RowType == DataControlRowType.Footer)
            {       
                _expCell = new TableCell();
                _ctlExpand = new HtmlAnchor();
                //_ctlExpand.HRef = "#";          -- Commenting this out worked!
                _ctlExpand.Attributes["onclick"] = "TglRow(this);";
                _ihExp = new HtmlInputHidden();
                _ihExp.ID = "e" + this.DataItemIndex.ToString();
                _expCell.Controls.Add(_ctlExpand);
                _expCell.Controls.Add(_ihExp);      
            }
            if (_expCell != null)
            {
                _expCell.Width = Unit.Pixel(20);
                Cells.AddAt(0, _expCell);
            }
