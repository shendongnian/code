    private void btnDisplayDetails_Click(object sender, RoutedEventArgs e)
        {
            Person person = _ucPersons.GetSelectedPerson();
            if (person != null)
            {
                lblName.Content = person.Name;
                lblAge.Content = person.BirthDay.ToShortDateString();
                Uri uri = new Uri( "m_" + person.ImageRef + ".jpg", 
                    UriKind.Relative);
                imgPerson.Source = BitmapFrame.Create(uri);
            }
        }
