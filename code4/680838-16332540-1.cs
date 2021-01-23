    TemplateField t = new TemplateField();
                DynamicTemplate mt = new DynamicTemplate(ListItemType.Item);
                mt.TableName = TableName;
                if (IsEditButtonVisible == 1)
                {
                    Image ibtnEdit = new Image();
                    ibtnEdit.ID = "btnEdit";
                    ibtnEdit.CssClass = "EditButton";
                    ibtnEdit.ImageUrl = EditButtonImageSrc;
                    ibtnEdit.Style.Add("cursor", "pointer");
                    ibtnEdit.ToolTip = "View Details";
                    mt.AddControl(ibtnEdit, "AlternateText", "Id");
                }
                if (IsDeleteButtonVisible == 1)
                {
                    Image ibtnDelete = new Image();
                    ibtnDelete.ID = "ibtnDelete";
                    ibtnDelete.CssClass = "DeleteButton";
                    ibtnDelete.ImageUrl = DeleteButtonImageSrc;
                    mt.AddControl(ibtnDelete, "AlternateText", "Id");
                }
                t.ItemTemplate = mt;
                t.HeaderText = "Activity";
                t.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                GridView1.Columns.Add(t);
            }
            GridView1.DataSource = dtOutPutResult;
            GridView1.DataBind();
