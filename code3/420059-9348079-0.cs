        // This Health variable looks like a read-only variable from the outside, but is still settable outside the constructor.
        public Single Health { get; private set; }
        // This Resistance variable looks like a read-only variable from the outside, but is still settable outside the constructor.
        public Single Resistance { get; private set; }
        public void Damage(Single amount)
        {
            this.Health -= Math.Max(amount - this.Resistance, 0.00f);
        }
    }
