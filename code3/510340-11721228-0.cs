    unit uEncDecTests_LockBox;
    
    interface
    
    uses
      Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
      Dialogs, StdCtrls, Buttons, uTPLb_BaseNonVisualComponent,
      uTPLb_Codec, uTPLb_CryptographicLibrary;
    
    type
      TFrmEncDecTests = class(TForm)
        EdtPlainText1: TEdit;
        EdtCypher: TEdit;
        Label1: TLabel;
        Label2: TLabel;
        EdtPlainText2: TEdit;
        Label3: TLabel;
        Label4: TLabel;
        BiBEncrypt: TBitBtn;
        BiBDecrypt: TBitBtn;
        Label5: TLabel;
        EdtKey: TEdit;
        Label6: TLabel;
        EdtCypher64: TEdit;
        EdtIV: TEdit;
        Label7: TLabel;
        Label8: TLabel;
        EdtCypherHex: TEdit;
        AESCodec: TCodec;
        CryptographicLibrary1: TCryptographicLibrary;
        BtnInit: TButton;
        procedure BiBEncryptClick(Sender: TObject);
        procedure BiBDecryptClick(Sender: TObject);
        procedure BtnInitClick(Sender: TObject);
      private
        FOut: String;
      public
        { Public declarations }
      end;
    
    var
      FrmEncDecTests: TFrmEncDecTests;
    
    implementation
    
    {$R *.dfm}
    
    procedure TFrmEncDecTests.BiBDecryptClick(Sender: TObject);
    var lPlainText: String;
    begin
      AESCodec.DecryptString(FOut,lPlainText);
      EdtPlainText2.Text := lPlainText;
    end;
    
    procedure TFrmEncDecTests.BiBEncryptClick(Sender: TObject);
    var
      lPlainText,
      sb,sh: String;
      b,o  : byte;
    begin
      lPlainText := EdtPlaintext1.Text;
      AESCodec.EncryptString(lPlainText,FOut);
      sh := '';
      sb := '';
      for B := 0 to Length(FOut) do begin
        o := Ord(FOut[b]);
        sh := sh + IntToHex(o,2) + ' ';
        if o < 10 then sb := sb + '0';
        if o < 100 then sb := sb + '0';
        sb := sb + inttostr(o) + ' ';
      end;
      EdtCypher.Text := FOut;
      EdtCypher64.Text := sb;
      EdtCypherHex.Text := sh;
    end;
    
    procedure TFrmEncDecTests.BtnInitClick(Sender: TObject);
    var
      p : PChar;
      MS: TMemoryStream;
    begin
      p := pChar(EdtKey.Text);
      MS := TMemoryStream.Create;
      MS.Write(P^,Length(EdtKey.Text));
      MS.Seek(soFromBeginning,0);
      AESCodec.InitFromStream(MS);
      MS.Free;
      BiBEncrypt.Enabled := true;
      BiBDecrypt.Enabled := true;
    end;
    
    end.
