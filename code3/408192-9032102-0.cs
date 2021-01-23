        private class mockdevice
        {
            public List<Value> listOfTrueReturn = new List<Value>();
            private Boolean flagvalue = false;
            public bool flag()
            {
                    return flagvalue;
            }
            public void setvalue(Value val)
            {
                if (listOfTrueReturn.Contains(val))
                {
                    flagvalue = true;
                }
                else
                {
                    flagvalue = false;
                }
            }
        }
        private delegate void setvalue(Value val);
        private delegate Boolean getflag();
        [Test]
        public void shouldAnswerStackoverflowQuestion()
        {
            float d = 5f;
            Value lower = new Value(-d, 0f, unit);
            Value higher = new Value(d, 0f, unit);
            mockdevice md = new mockdevice();
            md.listOfTrueReturn.Add(higher);
            IFindFlagDataObject mock = setupmock();
            mock.Expect(x => x.Lower).Return(lower);
            mock.Expect(x => x.Higher).Return(higher);
            mock.Expect(x => x.CheckFlag()).Do(new getflag(md.flag)).Repeat.Times(2);
            mock.Expect(x => x.SetValue(Arg<Value>.Is.Anything)).Do(new setvalue(md.setvalue)).Repeat.Times(2);
            FindFlagStrategy tested = new FindFlagStrategy(mock);
            tested.FindFlagValue();
            mock.VerifyAllExpectations();
            Mockuser tested = new Mockuser(mock)
            Assert.IsTrue(tested.setLowerAndCheckFlag());
            Assert.IsFalse(tested.setHigherAndCheckFlag());
        }
