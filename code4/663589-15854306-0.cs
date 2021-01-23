        public class Person
        {
            public bool UpdateFromOther(Person otherPerson)
            {
                var properties =
                    this.GetType()
                        .GetProperties(
                            BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty
                            | BindingFlags.GetProperty);
         
                var changed = properties.Any(prop =>
                {
                    var my = prop.GetValue(this);
                    var theirs = prop.GetValue(otherPerson);
                    return my != null ? !my.Equals(theirs) : theirs != null;
                });
                foreach (var propertyInfo in properties)
                {
                    propertyInfo.SetValue(this, propertyInfo.GetValue(otherPerson));
                }
                return changed;
            }
            public string Name { get; set; }
        }
        [Test]
        public void Test()
        {
            var instance1 = new Person() { Name = "Monkey" };
            var instance2 = new Person() { Name = "Magic" };
            var instance3 = new Person() { Name = null};
            Assert.IsFalse(instance1.UpdateFromOther(instance1), "No changes should be detected");
            Assert.IsTrue(instance2.UpdateFromOther(instance1), "Change is detected");
            Assert.AreEqual("Monkey",instance2.Name, "Property updated");
            Assert.IsTrue(instance3.UpdateFromOther(instance1), "Change is detected");
            Assert.AreEqual("Monkey", instance3.Name, "Property updated");
        }
