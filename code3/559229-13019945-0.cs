    String
      deletableTarget = @"\images\image1.jpeg", 
      hereWeAre = Environment.CurrentDirectory;
    MessageBox.Show("The taget path is:\n" + hereWeAre + deletableTarget);
    try
    {
      File.Delete(hereWeAre + deletableTarget);
    }
    catch (Exception exception)
    {
      MessageBox.Show(exception.Message);
    }
