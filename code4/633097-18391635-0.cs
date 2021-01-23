    #region IsInputKey(Keys keyData)
            protected override bool IsInputKey(Keys keyData)
            {
                if (keyData == Keys.Tab
                    //|| keyData.Equals(Keys.Up)
                    //|| keyData.Equals(Keys.Down)
                    //|| keyData.Equals(Keys.Left)
                    //|| keyData.Equals(Keys.Right)
                    || keyData.Equals(Keys.Enter)
                    || keyData.Equals(Keys.Escape)
                    || keyData.Equals(Keys.Space)
                    )
                    return true;
                
                return base.IsInputKey(keyData);
            }
            #endregion
