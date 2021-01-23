    for (int i = 0; i < Model.RowInput.Count; i++)
    {
        @Html.DropDownListFor(blah => blah.RowInputpi[i].InputtedData, ddv)
        @Html.HiddenFor(blah => blah.RowInput[i].InputtedDataID)
        @Html.HiddenFor(blah => blah.RowInput[i].RowCtrl.CtrlTypeID)
        ...
    }
