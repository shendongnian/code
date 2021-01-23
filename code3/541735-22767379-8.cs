    using System;
    using System.Text;
    using Common.Extensions;
    using Common.FluentValidation;
    using FluentAssertions;
    using NUnit.Framework;
    namespace UnitTests.CommonTests.Extensions
    {
        [TestFixture, Timeout(1000)]
        public class Span_Tests
        {
            // Test Anchoring
            [Test]
            public void Span_10_anchored_at_0_with_no_offset_should_be_0_Tests()
            {
                10.Span(0, 0).Should().Be(0);
            }
            [Test]
            public void Span_10_anchored_at_1_with_no_offset_should_be_1_Tests()
            {
                10.Span(1, 0).Should().Be(1);
            }
            [Test]
            public void Span_10_anchored_at_negative_1_with_no_offset_should_be_9_Tests()
            {
                10.Span(-1, 0).Should().Be(9);
            }
            [Test]
            public void Span_10_anchored_at_negative_10_with_no_offset_should_be_0_Tests()
            {
                10.Span(-10, 0).Should().Be(0);
            }
            // Test Offset
            [Test]
            public void Span_10_anchored_at_0_with_offset_of_1_should_be_1_Tests()
            {
                10.Span(0, 1).Should().Be(1);
            }
            [Test]
            public void Span_10_anchored_at_0_with_offset_of_negative_1_should_be_9_Tests()
            {
                10.Span(0, -1).Should().Be(9);
            }
            [Test]
            public void Span_10_anchored_at_0_with_offset_of_negative_10_should_be_0_Tests()
            {
                10.Span(0, -10).Should().Be(0);
            }
            // Test Iterations
            [Test]
            public void Span_array_of_10_anchored_at_0_can_walk_forward_thru_elements_twice_Tests()
            {
                var sb = new StringBuilder();
                try
                {
                    var SequentialData = new int[10];
                    for (int i = 0; i < SequentialData.Length; i++)
                        SequentialData[i] = i;
                    sb.AppendFormat("SequentialData:\r\n{0}", SequentialData.Print());
                    for (int i = 0; i < 20; i++)
                    {
                        var n = SequentialData.Length.Span(0, i);
                        SequentialData[n].Should().Be(i % 10);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(sb.ToString());
                    throw;
                }
            }
            [Test]
            public void Span_array_of_10_anchored_at_0_can_walk_backwards_thru_elements_twice_Tests()
            {
                var sb = new StringBuilder();
                try
                {
                    var SequentialData = new int[10];
                    for (int i = 0; i < SequentialData.Length; i++)
                        SequentialData[i] = i;
                    sb.AppendFormat("SequentialData:\r\n{0}", SequentialData.Print());
                    for (int i = 0; i > -20; i--)
                    {
                        var n = SequentialData.Length.Span(0, i);
                        var j = (i % 10);
                        switch (j)
                        {
                            case 0: SequentialData[n].Should().Be(0); break;
                            case -1: SequentialData[n].Should().Be(9); break;
                            case -2: SequentialData[n].Should().Be(8); break;
                            case -3: SequentialData[n].Should().Be(7); break;
                            case -4: SequentialData[n].Should().Be(6); break;
                            case -5: SequentialData[n].Should().Be(5); break;
                            case -6: SequentialData[n].Should().Be(4); break;
                            case -7: SequentialData[n].Should().Be(3); break;
                            case -8: SequentialData[n].Should().Be(2); break;
                            case -9: SequentialData[n].Should().Be(1); break;
                            default:
                                throw
                                    j.ToString().CannotBeSwitchedToDefault("j");
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(sb.ToString());
                    throw;
                }
            }
        }
    }
