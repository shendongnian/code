    var a1 = new List<string> { "A", "A", "B", "C", "D", "E", "E" };
    
    a1.ApplyCriteria("A").Criteria.Should().Be("A");
    a1.ApplyCriteria("A").Count.Should().Be(2);
    a1.ApplyCriteria("E").Criteria.Should().Be("E");
    a1.ApplyCriteria("E").Count.Should().Be(2);
    a1.ApplyCriteria("BCD").Criteria.Should().Be("BCD");
    a1.ApplyCriteria("BCD").Count.Should().Be(1);
    a1.ApplyCriteria("CD").Criteria.Should().Be("CD");
    a1.ApplyCriteria("CD").Count.Should().Be(1);
    // not found
    a1.ApplyCriteria("CDA").Criteria.Should().Be("CDA");
    a1.ApplyCriteria("CDA").Count.Should().Be(0);
