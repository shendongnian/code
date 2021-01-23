    private void grid1_MouseEnter(object sender, MouseEventArgs e)
            {
                //at first its normal size
                ScaleTransform st = new ScaleTransform(1, 1);
                //animation size to 1.25 persent of real size
                DoubleAnimation da = new  DoubleAnimation(1,1.25, new Duration(TimeSpan.FromSeconds(2)));
                //set transform to control
                grid1.RenderTransform = st;
                //animation transform now From Y And X
                st.BeginAnimation(ScaleTransform.ScaleXProperty, da);
                st.BeginAnimation(ScaleTransform.ScaleYProperty, da);
            }
