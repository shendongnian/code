    private void print_animation_of_card(System.Windows.Shapes.Rectangle card)
    {
        for (int i = 0; i <= 180; i++)
        {
            Thread.Sleep(3);
            Dispatcher.BeginInvoke(new a_dispatcher(() =>
            {
                //same code as topic method code
            }),null);
        }
    }
