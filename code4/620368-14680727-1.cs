        [TestMethod]
        public void CheckTagsTest()
        {
            // Whitespaces and commas only
            Assert.IsFalse(CheckTags("  \t \n \u1680"));
            Assert.IsFalse(CheckTags(" , , , "));
            Assert.IsFalse(CheckTags(",,,"));
            Assert.IsFalse(CheckTags(",, ,"));
            // 10 tags
            Assert.IsFalse(CheckTags(@"tag0,tag1,tag2,tag3,tag4,tag5,tag6,tag7,tag8,tag9"));
            // Duplicated tags
            Assert.IsFalse(CheckTags(@"tag0,tag0"));
            // A tag contains more than 30 characters
            Assert.IsFalse(CheckTags(@"abcdefghijklmnopqrstuvwxyz0123*"));
            // A tag contains invalid characters
            Assert.IsFalse(CheckTags(@"tag!"));
            Assert.IsFalse(CheckTags(@"tag*"));
            // Tag separator contains more than one whitespaces
            Assert.IsFalse(CheckTags(@"tag1, tag2,  tag3"));
            // Normal tags
            Assert.IsTrue(CheckTags(@"tag1, tag2, tag3"));
            Assert.IsTrue(CheckTags(@"tag1,tag2, tag3"));
            Assert.IsTrue(CheckTags("tag1,tag2,\ttag3, tag4"));
            // Ending tag separator is allowed
            Assert.IsTrue(CheckTags("tag1,tag2,\ttag3, tag4,"));
            Assert.IsTrue(CheckTags("tag1,tag2,\ttag3, tag4, "));
            // A tag contains 30 characters
            Assert.IsTrue(CheckTags(@"abcdefghijklmnopqrstuvwxyz0123"));
            // A tag contains '-'
            Assert.IsTrue(CheckTags(@"T-shirt"));
            Assert.IsTrue(CheckTags(@"-"));
            // A tag contains '_'
            Assert.IsTrue(CheckTags(@"T_shirt"));
            Assert.IsTrue(CheckTags(@"_"));
            // A tag contains chinese characters
            Assert.IsTrue(CheckTags("\u4E2D"));
        }
