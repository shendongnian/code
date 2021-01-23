    catch (ArgumentException ex)
    {
        MessageBox.Show("Hey you idiot, go into the application settings and specify a valid path","Error");
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
