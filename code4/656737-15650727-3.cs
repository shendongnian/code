    // Unless this NEEDS to be dynamic, move it into the declarative markup.
    // The dynamic control must be added to the *same location* it was before the
    // postback or there will be ugly invalid control tree creation exceptions.
    var radioList = new RadioButtonList();
    someControl.Controls.Add(radioList);
    // To minimize problem with Control Tree creation this should be unique and
    // consistent for dynamic controls.
    radioList.ID = "radioList";
    // Binding to the DS "declarative" usually works better I've found
    radioList.DataSourceID = "idOfTheGDS";
    // You -may- need to DataBind, depending upon a few factors - I will usually call
    // DataBind in PreRender, but generally in the Load is OK/preferred.
    // If it already binds, don't call it manually.
    radioList.DataBind();
