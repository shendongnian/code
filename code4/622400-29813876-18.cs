    using System;
    using DEMO.Common;
    using DEMO.DemoDataTransferObjects;
    namespace DemoConsoleApplication
    {
    public class DemoClass
    {
        public DemoClass()
        {
        }
        public void StartDemo()
        {
            this.ProcessDemo();
        }
        private void ProcessDemo()
        {
            DemoDTO dto = this.CreateDemoDto();
            
            // Serialize the dto to xml.
            string strXml = DTOSerializerHelper.SerializeDTO(dto);
            
            // Write the serialized dto as xml.
            Console.WriteLine("Serialized DTO");
            Console.WriteLine("=======================");
            Console.WriteLine("\r");
            Console.WriteLine(strXml);
            Console.WriteLine("\r");
            // Deserialize the xml to the data transfer object.
            DemoDTO desDto = 
              (DemoDTO) DTOSerializerHelper.DeserializeXml(strXml, 
              new DemoDTO());
            
            // Write the deserialized dto values.
            Console.WriteLine("Deseralized DTO");
            Console.WriteLine("=======================");
            Console.WriteLine("\r");
            Console.WriteLine("DemoId         : " + desDto.DemoId);
            Console.WriteLine("Demo Name      : " + desDto.DemoName);
            Console.WriteLine("Demo Programmer: " + desDto.DemoProgrammer);
            Console.WriteLine("\r");
        }
        private DemoDTO CreateDemoDto()
        {
            DemoDTO dto = new DemoDTO();
            
            dto.DemoId            = "1";
            dto.DemoName        = "Data Transfer Object Demonstration Program";
            dto.DemoProgrammer    = "Kenny Young";
            return dto;
        }
    }
