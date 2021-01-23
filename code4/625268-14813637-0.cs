    /// <summary>
        /// Operates the specified flag.
        /// </summary>
        /// <param name="flag">The flag.</param>
        /// <param name="operation">The operation.</param>
        public void Operate(FlagEnum flag, OperationEnum operation)
        {
            this.flag = flag;
            switch (operation)
            {
                case OperationEnum.AND:
                    operate((x, y) => x & y);
                    break;
                case OperationEnum.OR:
                    operate((x, y) => x | y);
                    break;
                case OperationEnum.XOR:
                    operate((x, y) => x ^ y);
                    break;
                case OperationEnum.NOT:
                    throw new NotImplementedException("The operation 'NOT' is not implemented so far!");
            }
        }
     /// <summary>
        /// Operates the specified operation.
        /// </summary>
        /// <param name="operation">The operation.</param>
        private void operate(Func<uint, uint, uint> operation)
        {
            this.Mask = operation(this.Mask, (uint)this.flag);
        }
        /// <summary>
        /// Clears the mask.
        /// </summary>
        public void ClearMask()
        {
            this.Mask = (uint)FlagEnum.Clear;
        }
