    <ScrollViewer VerticalScrollBarVisibility="Auto" Width="250" Height="500">
                    <WrapPanel Name="wrapboard" Orientation="Vertical" ></WrapPanel>
         </ScrollViewer>
    private void BtnAdd_Click(object sender, RoutedEventArgs e)
            {
                
                int heigt = 0;
                int wegt = 0;
                 if (!string.IsNullOrEmpty(txtHeight.Text) && !string.IsNullOrEmpty(txtWidth.Text))
                {
                    heigt = int.Parse(txtHeight.Text);
                    wegt = int.Parse(txtWidth.Text);
                }
                rect = new Rectangle();
                rect.Stroke = Brushes.Red;
                rect.StrokeThickness = 2;
                rect.Height = heigt;
                rect.Width = wegt;
                rect.Tag = val;
                wrapboard.Children.Add(rect);
                val = val + 1;
                //wrapboard is WrapPanel object
                foreach (UIElement ui in wrapboard.Children)
                {
                    if (ui.GetType() == typeof(Rectangle))
                    {
                        itemstoremove.Add(ui);
                    }
                }
            }
