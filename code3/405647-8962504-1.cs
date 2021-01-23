    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      Image1.ImageUrl = "~/Image.jpg"
    End Sub
    Protected Sub cropbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cropbtn.Click
      CropImage1.Crop(MapPath("croppedpictures.jpg"))
    End Sub
