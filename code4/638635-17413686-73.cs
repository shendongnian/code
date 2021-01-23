    public class ViewPager2 : ViewPager
    {
        public override void RequestChildFocus(View child, View focused)
        {
            // eat this request, which will prevent the ViewPager from setting the current item (fragment) the EditText 
            // is in (a child of), which causes an autoscroll (I'm using 1/2 page panels, so if a panel is to the 
            // right, and I click in its EditText, then not eating this would cause it to autoscroll to the left, since 
            // the ViewPager Adapter is based on whole pages, not halves).
    
            //base.RequestChildFocus(child, focused);
        }
    }
