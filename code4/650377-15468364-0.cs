    <#@ template debug="false" hostspecific="true" language="C#" #>
    <#@ assembly name="System.Core" #>
    <#@ import namespace="System.IO" #>
    <#@ import namespace="System.Linq" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ output extension=".generated.cs" #>
    <#
        var testCases =
            File.ReadAllLines(Path.Combine(Host.TemplateFile, @"Cases.csv"))
            .Skip(1)  //Headers
            .Select(line => line.Split(','))
            .Select(
                values =>
                    new
                    {
                        TestName = values[0],
                        Expected = values[1],
                        Actual = values[2],
                        //More Stuff from values[n]
                    });
    #>
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace DaveShaw
    {
        [TestClass]
        public class GeneratedTests
        {
    <#
        foreach (var testCase in testCases)
        {
    #>
            [TestMethod]
            public void Generated_<#= testCase.Name #>()
            {
                //Put your Arrange & Act code here
                Assert.AreEqual(
                    expected: <#= testCase.Expected #>
                    actual: <#= testCase.Expected #>);
            }
    <#
        }
    #>
        }
    }
