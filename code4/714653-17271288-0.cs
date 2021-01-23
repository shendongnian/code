    public static class ControlExtension {
         public static object Dispose2(this Control c){
             c.Dispose();
             return null;//or anything you want
         }
    }
    //Then
    var temp=(tableLayoutExamPanel.Controls.Find("lbl3", true)[0].Name==("lbl3")) ? (tableLayoutExamPanel.Controls.Find("lbl3", true)[0].Dispose2()) : null ;
