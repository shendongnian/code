    private async void btnSort_Click(object sender, RoutedEventArgs e)
    {
        // snip
        foreach (string f in result)
        {
            DateTime dest = GetDateTakenFromImage(f);
            await Archive(f, Destination, dest);
        }
    }
