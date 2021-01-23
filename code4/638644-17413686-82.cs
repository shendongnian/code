    public class ViewPager2 : ViewPager
    {
        private view _clearFocused;
        public override void RequestChildFocus(View child, View focused)
        {
            //base.RequestChildFocus(child, focused);
        }
         
        public void RequestChildFocus2(View child, View focused)
        {            
            if( _clearFocused != null )
            {
                _clearFocused.ClearFocus();
            }
            
            _clearFocused = focused;
            base.RequestChildFocus(child, focused);
        }
    }
