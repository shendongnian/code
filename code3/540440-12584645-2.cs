    using System.Collections.Generic;
    using System.Linq;
    using Android.GoogleMaps;
    using Android.Graphics.Drawables;
    using Android.OS;
    using Android.Views;
    using Java.Lang;
    
    namespace MapViewBalloons
    {
        public abstract class BalloonItemizedOverlay : ItemizedOverlay, View.IOnTouchListener, View.IOnClickListener
        {
    
            private static long BALLOON_INFLATION_TIME = 300;
            private static Handler _handler = new Handler();
    
            private MapView _mapView;
            private BalloonOverlayView _balloonView;
            private View _clickRegion;
            private View _closeRegion;
            private int _viewOffset;
            private MapController _mc;
            private OverlayItem _currentFocusedItem;
            private int _currentFocusedIndex;
    
            private float _startX,
                _startY;
    
            private bool _showClose = true;
            private bool _showDisclosure = false;
            private bool _snapToCenter = true;
    
            private static bool _isInflating = false;
            private BalloonRunnable _balloonRunnable;
    
            /**
             * Create a new BalloonItemizedOverlay
             * 
             * @param defaultMarker - A bounded Drawable to be drawn on the map for each item in the overlay.
             * @param mapView - The view upon which the overlay items are to be drawn.
             */
            public BalloonItemizedOverlay(Drawable defaultMarker, MapView mapView)
                : base(defaultMarker)
            {
                this._mapView = mapView;
                _viewOffset = 0;
                _mc = mapView.Controller;
    
                _balloonRunnable = new BalloonRunnable(this);
            }
    
            /**
             * Set the horizontal distance between the marker and the bottom of the information
             * balloon. The default is 0 which works well for center bounded markers. If your
             * marker is center-bottom bounded, call this before adding overlay items to ensure
             * the balloon hovers exactly above the marker. 
             * 
             * @param pixels - The padding between the center point and the bottom of the
             * information balloon.
             */
            public int BalloonBottomOffset
            {
                get { return _viewOffset; }
                set { _viewOffset = value; }
            }
    
            /**
             * Override this method to handle a "tap" on a balloon. By default, does nothing 
             * and returns false.
             * 
             * @param index - The index of the item whose balloon is tapped.
             * @param item - The item whose balloon is tapped.
             * @return true if you handled the tap, otherwise false.
             */
            protected bool OnBalloonTap(int index, OverlayItem item)
            {
                return false;
            }
    
            /**
             * Override this method to perform actions upon an item being tapped before 
             * its balloon is displayed.
             * 
             * @param index - The index of the item tapped.
             */
            protected void OnBalloonOpen(int index) { }
    
            protected override bool OnTap(int index)
            {
    
                _handler.RemoveCallbacks(_balloonRunnable);
                _isInflating = true;
                _handler.PostDelayed(_balloonRunnable, BALLOON_INFLATION_TIME);
    
                _currentFocusedIndex = index;
                _currentFocusedItem = CreateItem(index) as OverlayItem;
                SetLastFocusedIndex(index);
    
                OnBalloonOpen(index);
                CreateAndDisplayBalloonOverlay();
    
                if (_snapToCenter)
                {
                    animateTo(index, _currentFocusedItem.Point);
                }
    
                return true;
            }
    
            /**
             * Animates to the given center point. Override to customize how the
             * MapView is animated to the given center point
             *
             * @param index The index of the item to center
             * @param center The center point of the item
             */
            protected void animateTo(int index, GeoPoint center)
            {
                _mc.AnimateTo(center);
            }
    
            /**
             * Creates the balloon view. Override to create a sub-classed view that
             * can populate additional sub-views.
             */
            protected BalloonOverlayView CreateBalloonOverlayView()
            {
                return new BalloonOverlayView(GetMapView().Context, BalloonBottomOffset);
            }
    
            /**
             * Expose map view to subclasses.
             * Helps with creation of balloon views. 
             */
            protected MapView GetMapView()
            {
                return _mapView;
            }
    
            /**
             * Makes the balloon the topmost item by calling View.bringToFront().
             */
            public void BringBalloonToFront()
            {
                if (_balloonView != null)
                {
                    _balloonView.BringToFront();
                }
            }
    
            /**
             * Sets the visibility of this overlay's balloon view to GONE and unfocus the item. 
             */
            public void HideBalloon()
            {
                if (_balloonView != null)
                {
                    _balloonView.Visibility = ViewStates.Gone;
                }
                _currentFocusedItem = null;
            }
    
            /**
             * Hides the balloon view for any other BalloonItemizedOverlay instances
             * that might be present on the MapView.
             * 
             * @param overlays - list of overlays (including this) on the MapView.
             */
            private void HideOtherBalloons(List<Overlay> overlays)
            {
    
                foreach (var overlay in overlays)
                {
                    if (overlay is BalloonItemizedOverlay && overlay != this)
                    {
                        ((BalloonItemizedOverlay)overlay).HideBalloon();
                    }
                }
    
            }
    
            public void HideAllBalloons()
            {
                if (!_isInflating)
                {
                    List<Overlay> mapOverlays = _mapView.Overlays.ToList();
                    if (mapOverlays.Count > 1)
                    {
                        HideOtherBalloons(mapOverlays);
                    }
                    HideBalloon();
                }
            }
    
            public override Java.Lang.Object Focus
            {
                get
                {
                    return _currentFocusedItem;
                }
    
                set
                {
                    _currentFocusedIndex = LastFocusedIndex;
                    _currentFocusedItem = (OverlayItem)value;
                    if (_currentFocusedItem == null)
                    {
                        HideBalloon();
                    }
                    else
                    {
                        CreateAndDisplayBalloonOverlay();
                    }
                }
            }
    
            /**
             * Creates and displays the balloon overlay by recycling the current 
             * balloon or by inflating it from xml. 
             * @return true if the balloon was recycled false otherwise 
             */
            private bool CreateAndDisplayBalloonOverlay()
            {
                bool isRecycled;
                if (_balloonView == null)
                {
                    _balloonView = CreateBalloonOverlayView();
                    _clickRegion = (View)_balloonView.FindViewById(Resource.Id.balloon_inner_layout);
                    _clickRegion.SetOnTouchListener(this);
                    _closeRegion = (View)_balloonView.FindViewById(Resource.Id.balloon_close);
                    if (_closeRegion != null)
                    {
                        if (!_showClose)
                        {
                            _closeRegion.Visibility = ViewStates.Gone;
                        }
                        else
                        {
                            _closeRegion.SetOnClickListener(this);
                        }
                    }
                    if (_showDisclosure && !_showClose)
                    {
                        View v = _balloonView.FindViewById(Resource.Id.balloon_disclosure);
                        if (v != null)
                        {
                            v.Visibility = ViewStates.Visible;
                        }
                    }
                    isRecycled = false;
                }
                else
                {
                    isRecycled = true;
                }
    
                _balloonView.Visibility = ViewStates.Gone;
    
                List<Overlay> mapOverlays = _mapView.Overlays.ToList();
                if (mapOverlays.Count > 1)
                {
                    HideOtherBalloons(mapOverlays);
                }
    
                if (_currentFocusedItem != null)
                    _balloonView.SetData(_currentFocusedItem);
    
                GeoPoint point = _currentFocusedItem.Point;
                MapView.LayoutParams layoutParams = new MapView.LayoutParams(
                        MapView.LayoutParams.WrapContent, MapView.LayoutParams.WrapContent, point,
                        MapView.LayoutParams.BottomCenter);
                layoutParams.Mode = MapView.LayoutParams.ModeMap;
    
                _balloonView.Visibility = ViewStates.Visible;
    
                if (isRecycled)
                {
                    _balloonView.LayoutParameters = layoutParams;
                }
                else
                {
                    _mapView.AddView(_balloonView, layoutParams);
                }
    
                return isRecycled;
            }
    
            public void SetShowClose(bool showClose)
            {
                _showClose = showClose;
            }
    
            public void SetShowDisclosure(bool showDisclosure)
            {
                _showDisclosure = showDisclosure;
            }
    
            public void SetSnapToCenter(bool snapToCenter)
            {
                _snapToCenter = snapToCenter;
            }
    
            public bool IsInflating
            {
                get { return _isInflating; }
                set { _isInflating = value; }
            }
    
            private class BalloonRunnable : Java.Lang.Object, IRunnable
            {
                private BalloonItemizedOverlay _item;
                public BalloonRunnable(BalloonItemizedOverlay item)
                {
                    _item = item;
                }
    
                public void Run()
                {
                    _item.IsInflating = false;
                }
            }
    
            public bool OnTouch(View v, MotionEvent e)
            {
                View l = ((View)v.Parent).FindViewById(Resource.Id.balloon_main_layout);
                Drawable d = l.Background;
    
                if (e.Action == MotionEventActions.Down)
                {
                    if (d != null)
                    {
                        int[] states = { Android.Resource.Attribute.StatePressed };
                        if (d.SetState(states))
                        {
                            d.InvalidateSelf();
                        }
                    }
                    _startX = e.GetX();
                    _startY = e.GetY();
                    return true;
                }
                else if (e.Action == MotionEventActions.Up)
                {
                    if (d != null)
                    {
                        int[] newStates = { };
                        if (d.SetState(newStates))
                        {
                            d.InvalidateSelf();
                        }
                    }
                    if (Java.Lang.Math.Abs(_startX - e.GetX()) < 40 && Java.Lang.Math.Abs(_startY - e.GetY()) < 40)
                    {
                        // call overridden method
                        OnBalloonTap(_currentFocusedIndex, _currentFocusedItem);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
    
            public void OnClick(View v)
            {
                HideBalloon();
            }
        }
    }
