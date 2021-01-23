    public abstract class Animal
    {
        private int _movementSpeed;
        
        public int MovementSpeed
        {
            get
            {
                return _movementSpeed;
            }
            set
            {
                if (_movementSpeed != value)
                {
                    _movementSpeed = value;
                    OnMovementSpeedChanged();
                }
            }
        }
    
        protected virtual void OnMovementSpeedChanged()
        {
            // Derived classes can override this method.
            // It will be called each time MovementSpeed changes.
        }
        
        public virtual int Movement()
        {
            // always use the property to change the value
            // otherwise OnMovementSpeedChanged would never be called
            MovementSpeed -= tiredRate;
            return MovementSpeed;
        }
    }
