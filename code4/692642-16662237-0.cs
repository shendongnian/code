     private void Canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            double maxScale = 2.0;
            if (e.Delta > 0)
            {
                st.ScaleX *= ScaleRate;
                st.ScaleY *= ScaleRate;
            }
            else
            {
                st.ScaleX /= ScaleRate;
                st.ScaleY /= ScaleRate;
            }
            
            if(st.ScaleX > maxScale)
            {
                st.ScaleX = maxScale;
            }
            if(st.ScaleY > maxScale)
            {
                st.ScaleY = maxScale;
            }
        } 
