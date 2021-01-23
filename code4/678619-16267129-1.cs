    public static void Insert(string id, string agegroup, string gender, System.Drawing.Image photoa)
    {
       // code 
        cmd.Parameters.AddWithValue("@photo", imageToByteArray(photoa));
       // code 
    }
    public static byte[] imageToByteArray(System.Drawing.Image iImage)  
    {  
        MemoryStream mMemoryStream = new MemoryStream();  
        iImage.Save(mMemoryStream, System.Drawing.Imaging.ImageFormat.Png);  
        return mMemoryStream.ToArray();  
    }  
