    int i = 0;
    for (i = 1; i <= NumItems; i++) {
        if ((Information.VarType(ItemValues[i]) & ~VariantType.Array) != 0) {
            txtSubValue.Text = ItemValues[i];
        } else {
            Interaction.MsgBox("Data type return error, returned array, expected single item", MsgBoxStyle.Critical, "Data Change Error");
            return;
        }
    }
