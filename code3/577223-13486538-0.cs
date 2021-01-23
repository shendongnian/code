        protected void DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DownList.SelectedItem.Value)
            {
                case "view1":
                    MultiView1.SetActiveView(view1);
                    hdnCurrentView.Value = "View1";
                    break;
                case "view2":
                    MultiView1.SetActiveView(view2);
                    hdnCurrentView.Value = "View2";
                    break;
            }
        }
