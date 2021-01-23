    protected override OnInit( EventArgs e ){
        BuildDynamicControls();
        base.OnInit( e );
    }
    
    private void BuildDynamicControls(){
        var rb = new RadioButton{ ID = "rb" + ReportPKey, Text = "ReportName" };
        phUiControls.Controls.Add( rb );
        
        rb.CheckedChanged += (sender, e) => {
            // event handler code
        };
    }
