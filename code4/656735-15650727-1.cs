    // Unless this NEEDS to be dynamic, move it into the declarative markup
    var radioList = new RadioButtonList();
    radioList.ID = "radioList"; // minimize problem with Control Tree creation
    someControl.Controls.Add(radioList);
    // Binding to the DS "declarative" usually works better I've found
    radioList.DataSourceID = "idOfTheGDS";
    // You -may- need to DataBind, depending upon a few factors - I will usually call
    // DataBind in PreRender, but generally in the Load is OK/preferred.
    // If it already binds, don't call it manually.
    radioList.DataBind();
