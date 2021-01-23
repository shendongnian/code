    [TestFixture]
    public class Test
    {
        [Test]
        public void TestLongLength()
        {
            var s = new string('0', 78) + new string('1', 78) + new string('2', 42);
            var testClass = new TestClass();
            FillNoteProperties(s, testClass);
            Assert.AreEqual(new string('0', 78), testClass.NoteLine1);
            Assert.AreEqual(new string('1', 78), testClass.NoteLine2);
            Assert.AreEqual(new string('2', 42), testClass.NoteLine3);
        }
        public static void FillNoteProperties(string note, TestClass testClass)
        {
            var properties = testClass.GetType().GetProperties();
            var noteProperties = (from noteProperty in properties
                                  where noteProperty.Name.StartsWith("NoteLine", StringComparison.OrdinalIgnoreCase)
                                  orderby noteProperty.Name.Length, noteProperty.Name
                                  select noteProperty).ToList();                
            var i = 0;
            while (note.Length > 78)
            {
                noteProperties[i].SetValue(testClass, note.Substring(0, 78), null);
                note = note.Substring(78);
                i++;
            }
            noteProperties[i].SetValue(testClass, note, null);
        }
    }
