    Public void Repeater1OnItemDataBound(Object Sender, RepeaterItemEventArgs e) {
        HtmlGenericControl myDynamicRepeaterControl = 
         ((HtmlGenericControl)e.Item.FindControl("MyDiv"))
        //...do some work on myDynamicRepeaterControl 
    }
