    protected void imageAddExtraField_Click(object sender, ImageClickEventArgs e)
        {        
            // check if nothing in the session, on success create a new list
            if (Session["ExtraField"] == null)
            {
                Session["ExtraField"] = new List<ContentInfo>();
            }
            // get a reference to the list in session; previous code ensures is something
            List<ContentInfo> lstExtraFields = (List<ContentInfo>)Session["ExtraField"];
            ContentInfo obj = new ContentInfo();
            obj.ExtraFieldValue = ckEditorExtraField.Text;
            obj.ExtraField = ddlExtraField.SelectedItem.ToString();
            lstExtraFields.Add(obj);
            
            // bind the grid
            gdvExtraField.DataSource = lstExtraFields;
            gdvExtraField.DataBind();
            
            // how do you bind when !PostBack?
            }
        }
