    using System;
    using System.Collections.Generic;
    using System.Text;
    using Common.Extensions;
    using FluentAssertions;
    using NUnit.Framework;
    namespace UnitTests.CommonTests.Extensions
    {
        [TestFixture, Timeout(1000)]
        public class SpanRange_Tests
        {
            [Test]
            public void SpanRange_array_of_10_from_0_to_9_should_be_0_thru_9_Tests()
            {
                var sb = new StringBuilder();
                try
                {
                    var Expected = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                    var SequentialData = new int[10];
                    for (int i = 0; i < SequentialData.Length; i++)
                        SequentialData[i] = i;
                    sb.AppendFormat("SequentialData:\r\n{0}", SequentialData.Print());
                    sb.AppendLine();
                    var Range = new List<int>(SequentialData.SpanRange(0, 9));
                    sb.AppendFormat("Range:\r\n{0}", Range.Print());
                    Range.ShouldBeEquivalentTo(Expected);
                }
                catch (Exception)
                {
                    Console.WriteLine(sb.ToString());
                    throw;
                }
            }
            [Test]
            public void SpanRange_array_of_10_from_0_to_9_should_not_throw_ArgumentOutOfRangeException_Tests()
            {
                foreach (var item in new int[10].SpanRange(0, 9))
                { }
            }
            [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void SpanRange_array_of_10_from_0_to_10_should_throw_ArgumentOutOfRangeException_Tests()
            {
                foreach (var item in new int[10].SpanRange(0, 10))
                { }
            }
            [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void SpanRange_array_of_10_from_negative_1_to_9_should_throw_ArgumentOutOfRangeException_Tests()
            {
                foreach (var item in new int[10].SpanRange(-1, 9))
                { }
            }
            [Test]
            public void SpanRange_array_of_10_from_1_to_0_should_be_1_thru_9_then_0_Tests()
            {
                var sb = new StringBuilder();
                try
                {
                    var Expected = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
                    var SequentialData = new int[10];
                    for (int i = 0; i < SequentialData.Length; i++)
                        SequentialData[i] = i;
                    sb.AppendFormat("SequentialData:\r\n{0}", SequentialData.Print());
                    sb.AppendLine();
                    var Range = new List<int>(SequentialData.SpanRange(1, 0));
                    sb.AppendFormat("Range:\r\n{0}", Range.Print());
                    Range.ShouldBeEquivalentTo(Expected);
                }
                catch (Exception)
                {
                    Console.WriteLine(sb.ToString());
                    throw;
                }
            }
            [Test]
            public void SpanRange_array_of_10_from_1_to_3_should_be_1_thru_3_Tests()
            {
                var sb = new StringBuilder();
                try
                {
                    var Expected = new List<int>() { 1, 2, 3 };
                    var SequentialData = new int[10];
                    for (int i = 0; i < SequentialData.Length; i++)
                        SequentialData[i] = i;
                    sb.AppendFormat("SequentialData:\r\n{0}", SequentialData.Print());
                    sb.AppendLine();
                    var Range = new List<int>(SequentialData.SpanRange(1, 3));
                    sb.AppendFormat("Range:\r\n{0}", Range.Print());
                    Range.ShouldBeEquivalentTo(Expected);
                }
                catch (Exception)
                {
                    Console.WriteLine(sb.ToString());
                    throw;
                }
            }
            [Test]
            public void SpanRange_array_of_10_from_9_to_1_should_be_9_0_and_1_Tests()
            {
                var sb = new StringBuilder();
                try
                {
                    var Expected = new List<int>() { 9, 0, 1 };
                    var SequentialData = new int[10];
                    for (int i = 0; i < SequentialData.Length; i++)
                        SequentialData[i] = i;
                    sb.AppendFormat("SequentialData:\r\n{0}", SequentialData.Print());
                    sb.AppendLine();
                    var Range = new List<int>(SequentialData.SpanRange(9, 1));
                    sb.AppendFormat("Range:\r\n{0}", Range.Print());
                    Range.ShouldBeEquivalentTo(Expected);
                }
                catch (Exception)
                {
                    Console.WriteLine(sb.ToString());
                    throw;
                }
            }
            [Test]
            public void SpanRange_array_of_5_from_1_to_4_should_be_1_thru_4_Tests()
            {
                var sb = new StringBuilder();
                try
                {
                    var Expected = new List<int>() { 1, 2, 3, 4 };
                    var SequentialData = new int[5];
                    for (int i = 0; i < SequentialData.Length; i++)
                        SequentialData[i] = i;
                    sb.AppendFormat("SequentialData:\r\n{0}", SequentialData.Print());
                    sb.AppendLine();
                    var Range = new List<int>(SequentialData.SpanRange(1, 4));
                    sb.AppendFormat("Range:\r\n{0}", Range.Print());
                    Range.ShouldBeEquivalentTo(Expected);
                }
                catch (Exception)
                {
                    Console.WriteLine(sb.ToString());
                    throw;
                }
            }
            [Test]
            public void SpanRange_array_of_5_from_0_to_0_should_be_0_Tests()
            {
                var sb = new StringBuilder();
                try
                {
                    var Expected = new List<int>() { 0 };
                    var SequentialData = new int[5];
                    for (int i = 0; i < SequentialData.Length; i++)
                        SequentialData[i] = i;
                    sb.AppendFormat("SequentialData:\r\n{0}", SequentialData.Print());
                    sb.AppendLine();
                    var Range = new List<int>(SequentialData.SpanRange(0, 0));
                    sb.AppendFormat("Range:\r\n{0}", Range.Print());
                    Range.ShouldBeEquivalentTo(Expected);
                }
                catch (Exception)
                {
                    Console.WriteLine(sb.ToString());
                    throw;
                }
            }
            [Test]
            public void SpanRange_array_of_5_from_1_to_1_should_be_1_Tests()
            {
                var sb = new StringBuilder();
                try
                {
                    var Expected = new List<int>() { 1 };
                    var SequentialData = new int[5];
                    for (int i = 0; i < SequentialData.Length; i++)
                        SequentialData[i] = i;
                    sb.AppendFormat("SequentialData:\r\n{0}", SequentialData.Print());
                    sb.AppendLine();
                    var Range = new List<int>(SequentialData.SpanRange(1, 1));
                    sb.AppendFormat("Range:\r\n{0}", Range.Print());
                    Range.ShouldBeEquivalentTo(Expected);
                }
                catch (Exception)
                {
                    Console.WriteLine(sb.ToString());
                    throw;
                }
            }
            [Test]
            public void SpanRange_array_of_5_from_4_to_0_should_be_4_then_0_Tests()
            {
                var sb = new StringBuilder();
                try
                {
                    var Expected = new List<int>() { 4, 0 };
                    var SequentialData = new int[5];
                    for (int i = 0; i < SequentialData.Length; i++)
                        SequentialData[i] = i;
                    sb.AppendFormat("SequentialData:\r\n{0}", SequentialData.Print());
                    sb.AppendLine();
                    var Range = new List<int>(SequentialData.SpanRange(4, 0));
                    sb.AppendFormat("Range:\r\n{0}", Range.Print());
                    Range.ShouldBeEquivalentTo(Expected);
                }
                catch (Exception)
                {
                    Console.WriteLine(sb.ToString());
                    throw;
                }
            }
            [Test]
            public void SpanRange_array_of_5_from_1_to_0_should_be_1_thru_4_then_0_Tests()
            {
                var sb = new StringBuilder();
                try
                {
                    var Expected = new List<int>() { 1, 2, 3, 4, 0 };
                    var SequentialData = new int[5];
                    for (int i = 0; i < SequentialData.Length; i++)
                        SequentialData[i] = i;
                    sb.AppendFormat("SequentialData:\r\n{0}", SequentialData.Print());
                    sb.AppendLine();
                    var Range = new List<int>(SequentialData.SpanRange(1, 0));
                    sb.AppendFormat("Range:\r\n{0}", Range.Print());
                    Range.ShouldBeEquivalentTo(Expected);
                }
                catch (Exception)
                {
                    Console.WriteLine(sb.ToString());
                    throw;
                }
            }
        }
    }
