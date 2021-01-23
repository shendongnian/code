    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    namespace ConsoleApplication2
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var persons = XElement.Parse(xml);
                var seq2 = from person in persons.Descendants("person")
                           where (string) person.Descendants("value").Last() == "B"
                           select person;
                print(seq2);
            }
            private static void print<T>(IEnumerable<T> seq)
            {
                foreach (var item in seq)
                {
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine(item);
                }
                Console.WriteLine("-------------------------------------------------");
            }
            static string xml =
    @"<persons>
    <person>
        <id>200</id>
        <name>Peter</name>
        <age>25</age>
        <categories>
            <category>
                <date>2012-05-01</date>
                <value>B</value>
            </category>
            <category>
                <date>2013-01-01</date>
                <value>A</value>
            </category>
            <category>
                <date>2013-02-01</date>
                <value>C</value>
            </category>
        </categories>
    </person>
    <person>
        <id>201</id>
        <name>Mary</name>
        <age>25</age>
        <categories>
            <category>
                <date>2012-05-01</date>
                <value>A</value>
            </category>
            <category>
                <date>2013-01-01</date>
                <value>B</value>
            </category>
            <category>
                <date>2013-02-01</date>
                <value>C</value>
            </category>
        </categories>
    </person>
    <person>
        <id>202</id>
        <name>Midge</name>
        <age>25</age>
        <categories>
            <category>
                <date>2012-05-01</date>
                <value>C</value>
            </category>
            <category>
                <date>2013-01-01</date>
                <value>A</value>
            </category>
            <category>
                <date>2013-02-01</date>
                <value>B</value>
            </category>
        </categories>
    </person>
    </persons>
    ";
        }
    }
