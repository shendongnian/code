       private Office.CommandBarButton buttonOne;
            void createbutton()
    {
         Office.CommandBar newMenuBar = Inspector.CommandBars.Add("EAD", Office.MsoBarPosition.msoBarTop, false, true);
        buttonOne = (Office.CommandBarButton)newMenuBar.Controls.Add(Office.MsoControlType.msoControlButton, 1, missing, missing, true);buttonOne.Caption = "Ansari";
        buttonOne.Style = Office.MsoButtonStyle.msoButtonIconAndWrapCaptionBelow;                   
                                
        buttonOne.Picture = getImage();
        //Register send event handler
        buttonOne.Click += buttonOne_Click;
        newMenuBar.Visible = true;
    }
    void buttonOne_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
            {
                MessageBox.Show("Hi");
            }
    private stdole.IPictureDisp getImage()
            {
                stdole.IPictureDisp tempImage = null;
                try
                {
                    System.Drawing.Bitmap newIcon = Properties.Resources.Icon1;
                    System.Windows.Forms.ImageList newImageList = new System.Windows.Forms.ImageList();                             
                    newImageList.Images.Add(newIcon);
                    tempImage = ConvertImage.Convert(newImageList.Images[0]);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                return tempImage;
            }
              sealed public class ConvertImage : System.Windows.Forms.AxHost
        {
            private ConvertImage() : base(null)
            {
            }
    
            public static stdole.IPictureDisp Convert(System.Drawing.Image image)
            {            
                return (stdole.IPictureDisp)System.Windows.Forms.AxHost.GetIPictureDispFromPicture(image);
            }
        }     
    
    Note: Add image with name Icon1 in resource.        
