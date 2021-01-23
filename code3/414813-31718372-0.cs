    private void HideMyEditModule()
    {
        foreach (var item in lv_Uc_Module.Items)
        {
            PlaceHolder holder = item.FindControl("ph_Lv_EditModule") as PlaceHolder;
            if (holder!= null)
                holder.Visible = false;
        }
    }
