    using System;
    using Android.Content;
    using Android.GoogleMaps;
    using Android.Util;
    using Android.Views;
    using Android.Widget;
    
    namespace MapViewBalloons
    {
        /**
         * A view representing a MapView marker information balloon.
         * 
         * @author Jeff Gilfelt
         *
         */
        public class BalloonOverlayView : FrameLayout
        {
            private LinearLayout _layout;
            private TextView _title;
            private TextView _snippet;
    
            /**
             * Create a new BalloonOverlayView.
             * 
             * @param context - The activity context.
             * @param balloonBottomOffset - The bottom padding (in pixels) to be applied
             * when rendering this view.
             */
            public BalloonOverlayView(Context context, int balloonBottomOffset)
                : base(context)
            {
                SetPadding(10, 0, 10, balloonBottomOffset);
    
                _layout = new LimitLinearLayout(context);
                _layout.Visibility = ViewStates.Visible;
    
                SetupView(context, _layout);
    
                FrameLayout.LayoutParams layoutParams = new FrameLayout.LayoutParams(
                        LayoutParams.WrapContent, LayoutParams.WrapContent);
                layoutParams.Gravity = GravityFlags.NoGravity;
    
                AddView(_layout, layoutParams);
            }
    
            /**
             * Inflate and initialize the BalloonOverlayView UI. Override this method
             * to provide a custom view/layout for the balloon. 
             * 
             * @param context - The activity context.
             * @param parent - The root layout into which you must inflate your view.
             */
            protected void SetupView(Context context, ViewGroup parent)
            {
    
                LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
                View v = inflater.Inflate(Resource.Layout.balloon_overlay, parent);
                _title = (TextView)v.FindViewById(Resource.Id.balloon_item_title);
                _snippet = (TextView)v.FindViewById(Resource.Id.balloon_item_snippet);
    
            }
    
            /**
             * Sets the view data from a given overlay item.
             * 
             * @param item - The overlay item containing the relevant view data. 
             */
            public void setData(OverlayItem item)
            {
                _layout.Visibility = ViewStates.Visible;
                SetBalloonData(item, _layout);
            }
    
            /**
             * Sets the view data from a given overlay item. Override this method to create
             * your own data/view mappings.
             * 
             * @param item - The overlay item containing the relevant view data.
             * @param parent - The parent layout for this BalloonOverlayView.
             */
            protected void SetBalloonData(OverlayItem item, ViewGroup parent)
            {
                if (!string.IsNullOrEmpty(item.Title))
                {
                    _title.Visibility = ViewStates.Visible;
                    _title.Text = item.Title;
                }
                else
                {
                    _title.Text = "";
                    _title.Visibility = ViewStates.Gone;
                }
                if (!string.IsNullOrEmpty(item.Snippet))
                {
                    _snippet.Visibility = ViewStates.Visible;
                    _snippet.Text = item.Snippet;
                }
                else
                {
                    _snippet.Text = "";
                    _snippet.Visibility = ViewStates.Gone;
                }
            }
    
            private class LimitLinearLayout : LinearLayout
            {
    
                private static int MAX_WIDTH_DP = 280;
                private readonly float SCALE;
    
                public LimitLinearLayout(Context context)
                    : base(context)
                {
                    SCALE = context.Resources.DisplayMetrics.Density;
                }
    
                public LimitLinearLayout(Context context, IAttributeSet attrs)
                    : base(context, attrs)
                {
                    SCALE = context.Resources.DisplayMetrics.Density;
                }
    
                protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
                {
                    var mode = MeasureSpec.GetMode(widthMeasureSpec);
                    int measuredWidth = MeasureSpec.GetSize(widthMeasureSpec);
                    int adjustedMaxWidth = (int)(MAX_WIDTH_DP * SCALE + 0.5f);
                    int adjustedWidth = Math.Min(measuredWidth, adjustedMaxWidth);
                    int adjustedWidthMeasureSpec = MeasureSpec.MakeMeasureSpec(adjustedWidth, mode);
                    base.OnMeasure(adjustedWidthMeasureSpec, heightMeasureSpec);
                }
            }
        }
    }
