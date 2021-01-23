    //if your trying to hide it base on weather the ProfilePictureThumb is Null by putting:**
    
        <asp:Image ID="ProfileImage" Visible='<%# String.IsNullOrEmpty(Eval("ProfilePictureThumb").ToString())? false:true %>'  runat="server"   ImageUrl='<%# System.String.Format("/Images/{0}", DataBinder.Eval(Container.DataItem, "ProfilePictureThumb"))%>'  />
    
    //if you want to make it display a default image based on weather or not ProfilePicture is null:
    
        ImageUrl='<%# String.IsNullOrEmpty(Eval("ProfilePictureThumb").ToString())? System.String.Format("/Images/{0}", "defaultimage.jpg"):System.String.Format("/Images/{0}", DataBinder.Eval(Container.DataItem, "ProfilePictureThumb"))%>'
    
    //that way you don't need code behind. 
