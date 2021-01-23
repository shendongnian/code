            var res = (ResourceDictionary)Application.LoadComponent(new Uri("/Design/Style/TextAreaStyle.xaml", UriKind.Relative));
            var mcRtb = new RichTextBox {Style = (Style) res["TextBoxStyle"], Name = "Folha" + J};
            RegisterName("Folha" + J, mcRtb);
            mcRtb.TextChanged += McRtbContentControl;
            var gcrd = new RowDefinition();
            var gcrdspace = new RowDefinition();
            gcrd.Height = new GridLength(980);
            GridControl.RowDefinitions.Add(gcrd);
            Grid.SetColumn(mcRtb, 1);
            Grid.SetRow(mcRtb, 1 + I);
            GridControl.Children.Add(mcRtb);
            I += 2;
            J++;
            gcrdspace.Height = new GridLength(30);
            GridControl.RowDefinitions.Add(gcrdspace);
            mcRtb.Focus();
        }
