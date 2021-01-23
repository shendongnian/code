        void  pencereac<T> (int Ops) where T : Window , new()
        {
            if (!Application.Current.Windows.OfType<T>().Any()) // Check is Not Open, Open it.
            {
               var wind = new T();
                switch (Ops)
                {
                    case 1:
                        wind.ShowDialog();
                        break;
                    case 0:
                        wind.Show();
                        break;
                }
            }
            else Application.Current.Windows.OfType<T>().First().Activate(); // Is Open Activate it.
        }
