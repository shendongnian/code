        public class Data
        {
            public string MemberId { get; set; }
        }
        [TestMethod]
        public void Your_Code_Works()
        {
            // Arrange fake data.
            var hdnSelectedMemberList = "1,2,3,4";
            var lstMainMembers = new[]
                {
                    new Data { MemberId = "1" },
                    new Data { MemberId = "2" },
                    new Data { MemberId = "3" },
                    new Data { MemberId = "4" },
                    new Data { MemberId = "5" }
                };
            // Act - copy/pasted from StackOverflow
            string[] memberList = hdnSelectedMemberList.Split(',');
            var _lstFilteredMembers = lstMainMembers.Where(p => memberList.Contains(p.MemberId)).ToList();
            // Assert - All pass.
            Assert.AreEqual(4, _lstFilteredMembers.Count);
            Assert.AreEqual("1", _lstFilteredMembers[0].MemberId);
            Assert.AreEqual("2", _lstFilteredMembers[1].MemberId);
            Assert.AreEqual("3", _lstFilteredMembers[2].MemberId);
            Assert.AreEqual("4", _lstFilteredMembers[3].MemberId);
        }
