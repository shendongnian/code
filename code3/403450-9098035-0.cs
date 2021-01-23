        private class ld
        {
            public Boolean make<T>(T param, Func<T, bool> func) 
            {
                return func(param);
            }
        }
        private class box
        {
            public Boolean GetTrue() { return true; }
            public int Secret = 5;
        }
        [Test]
        public void shouldDemonstrateLambdaExpressions()
        {
            //Normal Boolean Statement with integer
            int a = 5;
            Assert.IsTrue(a == 5);
            Assert.IsFalse(a == 4);
            //Boolean Statement Expressed Via Simple Lambda Expression
            Func<int, bool> myFunc = x => x == 5;
            Assert.IsTrue(myFunc(5));
            Assert.IsFalse(myFunc(4));
            //Encapsuled Lambda Expression Called on Integer By Generic Class with integer
            ld t = new ld();
            Assert.IsTrue(t.make<int>(5,myFunc));
            Assert.IsFalse(t.make<int>(4, myFunc));
            //Encapsuled Lambda Expression Called on Integer By Generic Class with implicit Generics
            Assert.IsTrue(t.make(5, myFunc));
            //Simple Lambda Expression Called on Integer By Generic Class with implicit Generic
            Assert.IsTrue(t.make(20, (x => x == 20)));
            Assert.IsTrue(t.make(20, (x => x > 12)));
            Assert.IsTrue(t.make(20, (x => x < 100)));
            Assert.IsTrue(t.make(20, (x => true)));
            //Simple Lambda Expression Called on a Class By Generic Class with implicit Generic 
            //FULL LAMBDA POWER REACHED
            box b = new box();
            Assert.IsTrue(t.make(b, (x => x.GetTrue())));
            Assert.IsTrue(t.make(b, (x => x.Secret == 5)));
            Assert.IsFalse(t.make(b, (x => x.Secret == 4)));
        }
