    using System;
    namespace Azine_Library.Misc
    {
    
        /// <summary>
        /// Represents a way to delay something, eg. something an event handler does, update-ion of a control, object or to run a method, This class '<see cref="DelayUpdate"/>'
        /// is intended to be used as a delayer of some sort and contains an event, '<see cref="PushUpdate"/>' that would be subcribed to an event handler where then the code 
        /// intended to be delayed would go. This object also contains a method, '<see cref="delay"/>' that when called delays the code written/located within the event handler 
        /// that is handling the '<see cref="PushUpdate"/>' event. The method, <see cref="delay"/> should be called from an event handler or a method of some sort that would orginally 
        /// execute the code written/located within the event handler described above also. An example of how this object can interact with another object is described and documented in great detail
        /// within the documentation for "Azine_Library", also an example program is available with the documentation.
        /// </summary>
        public class DelayUpdate
        {
            // Written, 17.06.2017
    
            #region Fields / Properties
    
            /// <summary>
            /// Occurs when the provided time (interval:) has elapsed
            /// </summary>
            public event EventHandler PushUpdate;
            /// <summary>
            /// READONLY. the amount of times the timer has ticked since the last call to delay, (DelayUpdate.delay).
            /// </summary>
            public int updateCounter
            {
                get;
                private set;
            }
            /// <summary>
            /// The amount of time [this] waits for until it pushes the update. (Milliseconds). default value: '500'.
            /// </summary>
            public int interval
            {
                get;
                set;
            }
            /// <summary>
            /// Holds the amount of times [this] raises the "DelayUpate.PushUpdate" event every call to DelayUpdate.delay() method. default value: '1'.
            /// </summary>
            public int updatesPerPush
            {
                get;
                set;
            }
    
            private System.Diagnostics.Stopwatch stopWatch;
            private System.Windows.Forms.Timer timer;
    
            #endregion
    
            #region Constructors
    
            /// <summary>
            /// Initializes a new instance of type, 'DelayUpdate'; sets the classes' properties to the defaults.
            /// </summary>
            public DelayUpdate()
            {
                //Initializing Variables
                this.updateCounter = 0;
                this.interval = 500;
                this.updatesPerPush = 1;
                this.stopWatch = new System.Diagnostics.Stopwatch();
                this.timer = new System.Windows.Forms.Timer();
    
                //Sub-ing Events
                this.timer.Tick += this.Timer_Tick;
            }
    
            #endregion
    
            #region Methods
    
            /// <summary>
            /// Delays the raising of the event, PushUpdate; call this method when a property of an object has changed. eg, TextBox.TextChanged => DelayUpdate.delay();
            /// </summary>
            public void delay()
            {
                // Written, 13.06.2017
    
                this.timer.Start();
                this.stopWatch.Restart();
                this.updateCounter = 0;
            }
    
            #endregion
    
            #region Events
    
            /// <summary>
            /// Raises the 'DelayUpdate.PushUpdate' event.
            /// </summary>
            private void onPushUpdate()
            {
                //Written, 26.05.2017 : 5:22pm
    
                if (PushUpdate != null)
                    PushUpdate.Invoke(this, new EventArgs());
            }
    
            #endregion
    
            #region Event Handlers
    
            private void Timer_Tick(object sender, EventArgs e)
            {
                // Written, 13.06.2017
    
                if (this.stopWatch.ElapsedMilliseconds > this.interval)
                {
                    if (this.updateCounter < this.updatesPerPush)
                    {
                        this.timer.Stop();
                        this.onPushUpdate();
                    }
                    this.updateCounter++;
                }
            }
    
            #endregion
        }
    }
