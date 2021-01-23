    public class ParcelView : Activity, RecordView.IFragmentToViewPagerEvent
    {
        protected ViewPager _viewPager;
        private List<Android.App.Fragment> _fragments;
    		
        public interface IFragmentToViewPagerEvent
        {
    	...
            void ParcelRecordFieldClickEvent(Fragment child, View focused);
        }
    	
        public void ParcelRecordFieldClickEvent(Fragment child, View focused)
        {
            int fragPos = _fragments.FindIndex(p => { return p == child; });
                
            _viewPager.SetCurrentItem(fragPos,false);
        }	
    }
