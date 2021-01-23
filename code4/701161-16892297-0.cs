    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Globalization;
    
    // This is just an example directory, please use your fully qualified file path
    string oldFilePath = @"C:\Users\User\Desktop\image.JPG";
    // Get the path of the file, and append a trailing backslash
    string directory = System.IO.Path.GetDirectoryName(oldFilePath) + @"\";
    
    // Get the date property from the image
    Bitmap image = new Bitmap(oldFilePath);
    PropertyItem test = image.GetPropertyItem(0x132);
    
    // Extract the date property as a string
    System.Text.ASCIIEncoding a = new ASCIIEncoding();
    string date = a.GetString(test.Value, 0, test.Len - 1);
    
    // Create a DateTime object with our extracted date so that we can format it how we wish
    System.Globalization.CultureInfo provider = CultureInfo.InvariantCulture;
    DateTime dateCreated = DateTime.ParseExact(date, "yyyy:MM:d H:m:s", provider);
    
    // Create our own file friendly format of daydayMonthMonthYearYearYearYear
    string fileName = dateCreated.ToString("ddMMyyyy");
    
    // Create the new file path
    string newPath = directory + fileName + ".JPG";
    
    // Use this method to rename the file
    //System.IO.File.Move(oldFilePath, newPath);
    
    Console.WriteLine(newPath);
