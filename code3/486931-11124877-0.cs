    /// <summary>
    /// "Better" Behavior base class which allows for safe unsubscribing. The default Behavior class does not always call <see cref="Behavior.OnDetaching"/>
    /// </summary>
    /// <typeparam name="T">The dependency object this behavior should be attached to</typeparam> 
    public abstract class ZBehaviorBase<T> : Behavior<T> where T : FrameworkElement
    {
        private bool _isClean = true;
    
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
        protected sealed override void OnAttached()
        {
            base.OnAttached();
     
            AssociatedObject.Unloaded += OnAssociatedObjectUnloaded;
            _isClean = false;     
            ValidateRequiredProperties();     
            Initialize();
        }
     
        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>Override this to unhook functionality from the AssociatedObject.</remarks>
        protected sealed override void OnDetaching()
        {
            CleanUp();     
            base.OnDetaching();
        }
     
        /// <summary>
        /// Validates the required properties. This method is called when the object is attached, but before
        /// the <see cref="Initialize"/> is invoked.
        /// </summary>
        protected virtual void ValidateRequiredProperties()
        {
        }
     
        /// <summary>
        /// Initializes the behavior. This method is called instead of the <see cref="OnAttached"/> which is sealed
        /// to protect the additional behavior.
        /// </summary>
        protected abstract void Initialize();        
     
        /// <summary>
        /// Uninitializes the behavior. This method is called when <see cref="OnDetaching"/> is called, or when the
        /// <see cref="AttachedControl"/> is unloaded.
        /// <para />
        /// If dependency properties are used, it is very important to use <see cref="ClearValue"/> to clear the value
        /// of the dependency properties in this method.
        /// </summary>
        protected abstract void Uninitialize();
     
        /// <summary>
        /// Called when the <see cref="AssociatedObject"/> is unloaded.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnAssociatedObjectUnloaded(object sender, EventArgs e)
        {
            CleanUp();
        }
     
        /// <summary>
        /// Actually cleans up the behavior because <see cref="OnDetaching"/> is not always called.
        /// </summary>
        /// <remarks>
        /// This is based on the blog post: http://dotnetbyexample.blogspot.com/2011/04/safe-event-detachment-pattern-for.html.
        /// </remarks>
        private void CleanUp()
        {
            if (_isClean)
            {
                return;
            }
     
            _isClean = true;
     
            if (AssociatedObject != null)
            {
                AssociatedObject.Unloaded -= OnAssociatedObjectUnloaded;
            }
     
            Uninitialize();
        }
    }
