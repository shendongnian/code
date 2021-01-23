     pnlLost.Visible = false;
     pnlDoesNotWork.Visible = false;
     pnlNameChange.Visible = false;
     pnlTitleChange.Visible = false;
     pnlDeptLocation.Visible = false;
     pnlOther.Visible = false;
     switch (rblReason.SelectedItem.Text)
     {
            case "NotWork":
                pnlDoesNotWork.Visible = true;
                break;
            case "Name":
                pnlNameChange.Visible = true;            
                break;
            case "Title":
                pnlTitleChange.Visible = true;
                break;
            case "Dept":
                pnlDeptLocation.Visible = true;
                break;
            case "Other":
                pnlOther.Visible = true;
                break;
     }
