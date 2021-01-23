              GridEditableItem item = (GridEditableItem)e.Item;
              RadNumericTextBox txtNo = item.FindControl("txtNo") as RadNumericTextBox;
              txtNo.Value = 7;
        }
 
}
