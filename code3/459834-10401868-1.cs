        [TestMethod]
        public void CheckDifferences()
        {
            var f = new OverridingGetHashCode();
            var g = new OverridingGetHashCode();
            f.GetDifferentProperties(g).Should().NotBeNull().And.BeEmpty();
            f.Include = true;
            f.GetDifferentProperties(g).Should().NotBeNull().And.HaveCount(1).And.Contain(f.GetType().GetProperty("Include"));
            g.Include = true;
            f.GetDifferentProperties(g).Should().NotBeNull().And.BeEmpty();
            g.JobDescription = "my job";
            f.GetDifferentProperties(g).Should().NotBeNull().And.HaveCount(1).And.Contain(f.GetType().GetProperty("JobDescription"));
        }
        [TestMethod]
        public void SetDifferences()
        {
            var f = new OverridingGetHashCode();
            var g = new OverridingGetHashCode();
            g.Include = true;
            f.SetDifferences(g);
            f.GetDifferentProperties(g).Should().NotBeNull().And.BeEmpty();
            f.Include = true;
            g.Include = false;
            f.SetDifferences(g);
            f.GetDifferentProperties(g).Should().NotBeNull().And.BeEmpty();
            f.Include.Should().BeFalse();
        }
